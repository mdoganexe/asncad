import { useState, useRef, useCallback } from 'react';
import type { CadEngine } from '../core/CadEngine';

interface CommandInputProps {
  engine: CadEngine | null;
}

/**
 * Text input for commands and numeric input.
 * Supports entering tool names, numeric values, and coordinates.
 */
export default function CommandInput({ engine }: CommandInputProps) {
  const [value, setValue] = useState('');
  const [history, setHistory] = useState<string[]>([]);
  const [historyIndex, setHistoryIndex] = useState(-1);
  const inputRef = useRef<HTMLInputElement>(null);

  const handleSubmit = useCallback(() => {
    if (!engine || !value.trim()) return;
    const cmd = value.trim();

    // Add to history
    setHistory((prev) => [cmd, ...prev.slice(0, 49)]);
    setHistoryIndex(-1);
    setValue('');

    // Try as numeric input first
    const num = parseFloat(cmd);
    if (!isNaN(num)) {
      engine.handleNumericInput(num);
      return;
    }

    // Try as tool name
    const toolMap: Record<string, string> = {
      l: 'line', line: 'line',
      pl: 'polyline', polyline: 'polyline',
      rec: 'rectangle', rectangle: 'rectangle',
      c: 'circle', circle: 'circle',
      a: 'arc', arc: 'arc',
      dim: 'dimension', dimension: 'dimension',
      t: 'text', text: 'text',
      m: 'move', move: 'move',
      co: 'copy', copy: 'copy',
      ro: 'rotate', rotate: 'rotate',
      sc: 'scale', scale: 'scale',
      mi: 'mirror', mirror: 'mirror',
      o: 'offset', offset: 'offset',
      s: 'select', select: 'select',
    };

    const toolName = toolMap[cmd.toLowerCase()];
    if (toolName) {
      engine.activateTool(toolName as any);
      return;
    }

    // Special commands
    if (cmd.toLowerCase() === 'u' || cmd.toLowerCase() === 'undo') {
      engine.undo();
    } else if (cmd.toLowerCase() === 'redo') {
      engine.redo();
    } else if (cmd.toLowerCase() === 'del' || cmd.toLowerCase() === 'delete') {
      engine.deleteSelected();
    }
  }, [engine, value]);

  const handleKeyDown = (e: React.KeyboardEvent) => {
    if (e.key === 'Enter') {
      handleSubmit();
    } else if (e.key === 'ArrowUp') {
      e.preventDefault();
      if (history.length > 0) {
        const newIdx = Math.min(historyIndex + 1, history.length - 1);
        setHistoryIndex(newIdx);
        setValue(history[newIdx]);
      }
    } else if (e.key === 'ArrowDown') {
      e.preventDefault();
      if (historyIndex > 0) {
        const newIdx = historyIndex - 1;
        setHistoryIndex(newIdx);
        setValue(history[newIdx]);
      } else {
        setHistoryIndex(-1);
        setValue('');
      }
    } else if (e.key === 'Escape') {
      setValue('');
      engine?.cancelCurrentTool();
    }
  };

  return (
    <div style={{ display: 'flex', alignItems: 'center', gap: 6, padding: '4px 8px', background: '#1e293b', borderTop: '1px solid var(--border)' }}>
      <span style={{ color: '#94a3b8', fontSize: 12, fontWeight: 600 }}>Komut:</span>
      <input
        ref={inputRef}
        value={value}
        onChange={(e) => setValue(e.target.value)}
        onKeyDown={handleKeyDown}
        placeholder="Komut veya değer girin..."
        style={{
          flex: 1,
          background: '#0f172a',
          color: '#e2e8f0',
          border: '1px solid #334155',
          borderRadius: 4,
          padding: '4px 8px',
          fontSize: 13,
          fontFamily: 'monospace',
          outline: 'none',
        }}
      />
    </div>
  );
}
