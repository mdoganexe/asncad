import type { ParametricBlockDef, CadEntity, LiftParams } from '../core/types';
import { CabinBlock } from './CabinBlock';
import { GuideRailBlock } from './GuideRailBlock';
import { DoorBlock } from './DoorBlock';
import { CounterweightBlock } from './CounterweightBlock';
import { TractionMachineBlock } from './TractionMachineBlock';
import { BufferBlock } from './BufferBlock';
import { SafetyGearBlock } from './SafetyGearBlock';
import { GovernorBlock } from './GovernorBlock';
import { ControlPanelBlock } from './ControlPanelBlock';

/**
 * Registry of parametric block definitions for elevator components.
 */
export class BlockLibrary {
  private definitions: Map<string, ParametricBlockDef> = new Map();

  /** Register a parametric block definition. */
  register(def: ParametricBlockDef): void {
    this.definitions.set(def.name, def);
  }

  /** Get a block definition by name. */
  get(name: string): ParametricBlockDef | undefined {
    return this.definitions.get(name);
  }

  /** Get all registered block definitions. */
  getAll(): ParametricBlockDef[] {
    return Array.from(this.definitions.values());
  }

  /**
   * Resolve a block definition with specific lift parameters.
   * Returns the generated entities with resolved parameter values.
   */
  resolve(name: string, liftParams: LiftParams): CadEntity[] {
    const def = this.definitions.get(name);
    if (!def) return [];

    // Map lift params to block-local params using parameterBindings
    const localParams: Record<string, number> = {};
    for (const [localName, liftParamName] of Object.entries(def.parameterBindings)) {
      const value = (liftParams as any)[liftParamName];
      if (typeof value === 'number') {
        localParams[localName] = value;
      }
      // Handle nested specs
      if (liftParamName.includes('.')) {
        const parts = liftParamName.split('.');
        let obj: any = liftParams;
        for (const part of parts) {
          obj = obj?.[part];
        }
        if (typeof obj === 'number') {
          localParams[localName] = obj;
        }
      }
    }

    return def.generate(localParams);
  }

  /** Register all built-in elevator component blocks. */
  registerBuiltins(): void {
    this.register(new CabinBlock());
    this.register(new GuideRailBlock());
    this.register(new DoorBlock());
    this.register(new CounterweightBlock());
    this.register(new TractionMachineBlock());
    this.register(new BufferBlock());
    this.register(new SafetyGearBlock());
    this.register(new GovernorBlock());
    this.register(new ControlPanelBlock());
  }
}
