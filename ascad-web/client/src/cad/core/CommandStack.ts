import type { Command } from './types';

/**
 * A grouped command that wraps multiple sub-commands into a single undoable unit.
 */
class GroupCommand implements Command {
  readonly description: string;
  readonly commands: Command[] = [];

  constructor(description: string) {
    this.description = description;
  }

  execute(): void {
    for (const cmd of this.commands) {
      cmd.execute();
    }
  }

  undo(): void {
    // Undo in reverse order
    for (let i = this.commands.length - 1; i >= 0; i--) {
      this.commands[i].undo();
    }
  }
}

/**
 * Implements the Command pattern for undo/redo.
 * Each command captures the forward and reverse operations.
 */
export class CommandStack {
  private undoStack: Command[] = [];
  private redoStack: Command[] = [];
  private maxLevels: number;
  private activeGroup: GroupCommand | null = null;

  constructor(maxLevels = 100) {
    this.maxLevels = maxLevels;
  }

  /**
   * Execute a command, push to undo stack, clear redo stack.
   * If a group is active, add to the group instead.
   */
  execute(command: Command): void {
    command.execute();

    if (this.activeGroup) {
      this.activeGroup.commands.push(command);
      return;
    }

    this.undoStack.push(command);
    this.redoStack.length = 0;

    // Enforce max levels
    if (this.undoStack.length > this.maxLevels) {
      this.undoStack.shift();
    }
  }

  /**
   * Undo the most recent command.
   * @returns true if an undo was performed
   */
  undo(): boolean {
    const command = this.undoStack.pop();
    if (!command) return false;
    command.undo();
    this.redoStack.push(command);
    return true;
  }

  /**
   * Redo the most recently undone command.
   * @returns true if a redo was performed
   */
  redo(): boolean {
    const command = this.redoStack.pop();
    if (!command) return false;
    command.execute();
    this.undoStack.push(command);
    return true;
  }

  canUndo(): boolean {
    return this.undoStack.length > 0;
  }

  canRedo(): boolean {
    return this.redoStack.length > 0;
  }

  clear(): void {
    this.undoStack.length = 0;
    this.redoStack.length = 0;
    this.activeGroup = null;
  }

  /**
   * Begin grouping subsequent commands into a single undoable unit.
   */
  beginGroup(description: string): void {
    this.activeGroup = new GroupCommand(description);
  }

  /**
   * End the current group and push it as a single command to the undo stack.
   */
  endGroup(): void {
    if (!this.activeGroup) return;
    const group = this.activeGroup;
    this.activeGroup = null;

    if (group.commands.length > 0) {
      this.undoStack.push(group);
      this.redoStack.length = 0;

      if (this.undoStack.length > this.maxLevels) {
        this.undoStack.shift();
      }
    }
  }

  getUndoCount(): number {
    return this.undoStack.length;
  }

  getRedoCount(): number {
    return this.redoStack.length;
  }
}
