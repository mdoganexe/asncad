import type { ParametricBlockDef, BlockAttributeDef, CadEntity } from '../core/types';

/**
 * Base helper for creating parametric block definitions.
 * Subclasses implement the `generate` method to produce entities from parameters.
 */
export abstract class BaseParametricBlock implements ParametricBlockDef {
  abstract readonly name: string;
  abstract readonly displayName: string;
  abstract readonly parameterBindings: Record<string, string>;
  abstract readonly attributeDefinitions: BlockAttributeDef[];

  abstract generate(params: Record<string, number>): CadEntity[];

  /**
   * Resolve lift parameters to block-local parameters using parameterBindings.
   */
  resolveParams(liftParams: Record<string, any>): Record<string, number> {
    const resolved: Record<string, number> = {};
    for (const [localName, liftParamName] of Object.entries(this.parameterBindings)) {
      const value = liftParams[liftParamName];
      if (typeof value === 'number') {
        resolved[localName] = value;
      }
    }
    return resolved;
  }
}
