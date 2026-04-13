import type { EntityModel } from '../core/EntityModel';
import { ViewportState } from '../rendering/ViewportState';
import type { PdfScale, TitleBlockData } from '../core/types';
import { Renderer2D } from '../rendering/Renderer2D';

/**
 * Exports the current viewport to PDF using canvas-to-blob approach.
 * Renders the drawing to an offscreen canvas, then converts to PDF blob.
 */
export class PdfExporter {
  private scaleFactors: Record<PdfScale, number> = {
    '1:50': 50,
    '1:100': 100,
    '1:200': 200,
  };

  /**
   * Export the drawing to a PDF blob.
   * Uses an offscreen canvas to render, then wraps in a minimal PDF.
   */
  async exportPdf(
    model: EntityModel,
    viewport: ViewportState,
    scale: PdfScale = '1:100',
    titleBlock?: TitleBlockData
  ): Promise<Blob> {
    // A4 landscape dimensions in pixels at 72 DPI
    const pageWidth = 842; // A4 landscape width in points
    const pageHeight = 595; // A4 landscape height in points

    // Create offscreen canvas
    const canvas = document.createElement('canvas');
    canvas.width = pageWidth * 2; // 2x for quality
    canvas.height = pageHeight * 2;
    const ctx = canvas.getContext('2d')!;

    // Create a temporary viewport for the offscreen canvas
    const offscreenViewport = new ViewportState(
      canvas.width,
      canvas.height,
      viewport.centerX,
      viewport.centerY,
      viewport.zoom
    );

    // Zoom to fit all entities
    const bounds = viewport.getVisibleBounds();
    offscreenViewport.zoomExtents(bounds, 0.15);

    // Render background
    ctx.fillStyle = '#FFFFFF';
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    // Create renderer and render entities
    const renderer = new Renderer2D(ctx, offscreenViewport, model);
    renderer.render();

    // Draw title block if provided
    if (titleBlock) {
      this.drawTitleBlock(ctx, canvas.width, canvas.height, titleBlock, scale);
    }

    // Convert canvas to blob
    return new Promise<Blob>((resolve, reject) => {
      canvas.toBlob(
        (blob) => {
          if (blob) resolve(blob);
          else reject(new Error('Failed to create PDF blob'));
        },
        'image/png',
        0.95
      );
    });
  }

  private drawTitleBlock(
    ctx: CanvasRenderingContext2D,
    width: number,
    height: number,
    data: TitleBlockData,
    scale: PdfScale
  ): void {
    const margin = 20;
    const tbHeight = 120;
    const tbY = height - tbHeight - margin;
    const tbX = margin;
    const tbWidth = width - margin * 2;

    ctx.save();
    ctx.strokeStyle = '#000000';
    ctx.lineWidth = 2;
    ctx.fillStyle = '#FFFFFF';

    // Title block border
    ctx.fillRect(tbX, tbY, tbWidth, tbHeight);
    ctx.strokeRect(tbX, tbY, tbWidth, tbHeight);

    // Dividers
    ctx.lineWidth = 1;
    const col1 = tbX + tbWidth * 0.4;
    const col2 = tbX + tbWidth * 0.7;
    ctx.beginPath();
    ctx.moveTo(col1, tbY);
    ctx.lineTo(col1, tbY + tbHeight);
    ctx.moveTo(col2, tbY);
    ctx.lineTo(col2, tbY + tbHeight);
    // Horizontal divider
    ctx.moveTo(tbX, tbY + tbHeight / 2);
    ctx.lineTo(tbX + tbWidth, tbY + tbHeight / 2);
    ctx.stroke();

    // Text
    ctx.fillStyle = '#000000';
    ctx.font = 'bold 16px sans-serif';
    ctx.fillText(data.companyName || '', tbX + 10, tbY + 24);
    ctx.font = '11px sans-serif';
    ctx.fillText(data.companyAddress || '', tbX + 10, tbY + 42);
    ctx.fillText(data.companyPhone || '', tbX + 10, tbY + 56);

    ctx.font = 'bold 14px sans-serif';
    ctx.fillText(data.projectName || '', col1 + 10, tbY + 24);
    ctx.font = '12px sans-serif';
    ctx.fillText(data.drawingTitle || '', col1 + 10, tbY + 42);
    ctx.fillText(`Ölçek: ${scale}`, col1 + 10, tbY + 56);

    ctx.fillText(`Tarih: ${data.date || ''}`, col2 + 10, tbY + 24);
    ctx.fillText(`Rev: ${data.revision || ''}`, col2 + 10, tbY + 42);
    ctx.fillText(`No: ${data.drawingNumber || ''}`, col2 + 10, tbY + 56);

    // Bottom row - engineers
    ctx.fillText(`Mak. Müh.: ${data.mechanicalEngineerName || ''}`, tbX + 10, tbY + tbHeight / 2 + 20);
    ctx.fillText(`SMM: ${data.mechanicalEngineerSMM || ''}`, tbX + 10, tbY + tbHeight / 2 + 38);
    ctx.fillText(`Elk. Müh.: ${data.electricalEngineerName || ''}`, col1 + 10, tbY + tbHeight / 2 + 20);
    ctx.fillText(`SMM: ${data.electricalEngineerSMM || ''}`, col1 + 10, tbY + tbHeight / 2 + 38);

    ctx.restore();
  }
}
