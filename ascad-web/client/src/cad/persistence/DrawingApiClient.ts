import type { DrawingJson, DrawingType } from '../core/types';
import api from '../../api/client';

/**
 * Client for the drawing persistence API.
 * Handles save/load of CAD drawing JSON to the backend.
 */
export class DrawingApiClient {
  private maxRetries = 3;
  private baseDelay = 500; // ms

  /**
   * Save a drawing to the server.
   * POST /api/drawings/{liftId}/{type}
   */
  async saveDrawing(liftId: string, type: DrawingType, json: DrawingJson): Promise<void> {
    await this.withRetry(async () => {
      await api.post(`/drawings/${liftId}/${type}`, json);
    });
  }

  /**
   * Load a drawing from the server.
   * GET /api/drawings/{liftId}/{type}
   * Returns null if no saved drawing exists (404).
   */
  async loadDrawing(liftId: string, type: DrawingType): Promise<DrawingJson | null> {
    return this.withRetry(async () => {
      try {
        const response = await api.get<DrawingJson>(`/drawings/${liftId}/${type}`);
        return response.data;
      } catch (err: any) {
        if (err?.response?.status === 404) {
          return null;
        }
        throw err;
      }
    });
  }

  /**
   * Retry wrapper with exponential backoff.
   */
  private async withRetry<T>(fn: () => Promise<T>): Promise<T> {
    let lastError: any;
    for (let attempt = 0; attempt < this.maxRetries; attempt++) {
      try {
        return await fn();
      } catch (err: any) {
        lastError = err;
        // Don't retry on 4xx client errors (except 408, 429)
        const status = err?.response?.status;
        if (status && status >= 400 && status < 500 && status !== 408 && status !== 429) {
          throw err;
        }
        // Exponential backoff
        if (attempt < this.maxRetries - 1) {
          await this.delay(this.baseDelay * Math.pow(2, attempt));
        }
      }
    }
    throw lastError;
  }

  private delay(ms: number): Promise<void> {
    return new Promise((resolve) => setTimeout(resolve, ms));
  }
}
