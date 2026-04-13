/**
 * Low-level DXF string builder for group codes (code/value pairs).
 * DXF files are composed of group code pairs: an integer code on one line,
 * followed by the value on the next line.
 */
export class DxfWriter {
  private lines: string[] = [];

  /** Write a group code/value pair. */
  writeGroupCode(code: number, value: string | number): void {
    this.lines.push(`  ${code}`);
    this.lines.push(typeof value === 'number' ? value.toString() : value);
  }

  /** Write the HEADER section with standard variables. */
  writeHeader(extMin?: { x: number; y: number }, extMax?: { x: number; y: number }): void {
    this.writeGroupCode(0, 'SECTION');
    this.writeGroupCode(2, 'HEADER');

    // AutoCAD version AC1027 = AutoCAD 2013
    this.writeGroupCode(9, '$ACADVER');
    this.writeGroupCode(1, 'AC1027');

    // Insertion base point
    this.writeGroupCode(9, '$INSBASE');
    this.writeGroupCode(10, 0);
    this.writeGroupCode(20, 0);
    this.writeGroupCode(30, 0);

    // Drawing extents
    if (extMin) {
      this.writeGroupCode(9, '$EXTMIN');
      this.writeGroupCode(10, extMin.x);
      this.writeGroupCode(20, extMin.y);
      this.writeGroupCode(30, 0);
    }
    if (extMax) {
      this.writeGroupCode(9, '$EXTMAX');
      this.writeGroupCode(10, extMax.x);
      this.writeGroupCode(20, extMax.y);
      this.writeGroupCode(30, 0);
    }

    this.writeGroupCode(0, 'ENDSEC');
  }

  /** Write the TABLES section start. */
  writeTablesStart(): void {
    this.writeGroupCode(0, 'SECTION');
    this.writeGroupCode(2, 'TABLES');
  }

  /** Write the TABLES section end. */
  writeTablesEnd(): void {
    this.writeGroupCode(0, 'ENDSEC');
  }

  /** Write standard line type table entries. */
  writeLineTypes(): void {
    this.writeGroupCode(0, 'TABLE');
    this.writeGroupCode(2, 'LTYPE');
    this.writeGroupCode(70, 4);

    // CONTINUOUS
    this.writeGroupCode(0, 'LTYPE');
    this.writeGroupCode(2, 'CONTINUOUS');
    this.writeGroupCode(70, 0);
    this.writeGroupCode(3, 'Solid line');
    this.writeGroupCode(72, 65);
    this.writeGroupCode(73, 0);
    this.writeGroupCode(40, 0);

    // DASHED
    this.writeGroupCode(0, 'LTYPE');
    this.writeGroupCode(2, 'DASHED');
    this.writeGroupCode(70, 0);
    this.writeGroupCode(3, '__ __ __ __');
    this.writeGroupCode(72, 65);
    this.writeGroupCode(73, 2);
    this.writeGroupCode(40, 15);
    this.writeGroupCode(49, 10);
    this.writeGroupCode(49, -5);

    // CENTER
    this.writeGroupCode(0, 'LTYPE');
    this.writeGroupCode(2, 'CENTER');
    this.writeGroupCode(70, 0);
    this.writeGroupCode(3, '____ _ ____ _');
    this.writeGroupCode(72, 65);
    this.writeGroupCode(73, 4);
    this.writeGroupCode(40, 35);
    this.writeGroupCode(49, 20);
    this.writeGroupCode(49, -5);
    this.writeGroupCode(49, 5);
    this.writeGroupCode(49, -5);

    // HIDDEN
    this.writeGroupCode(0, 'LTYPE');
    this.writeGroupCode(2, 'HIDDEN');
    this.writeGroupCode(70, 0);
    this.writeGroupCode(3, '_ _ _ _');
    this.writeGroupCode(72, 65);
    this.writeGroupCode(73, 2);
    this.writeGroupCode(40, 10);
    this.writeGroupCode(49, 5);
    this.writeGroupCode(49, -5);

    this.writeGroupCode(0, 'ENDTAB');
  }

  /** Write the BLOCKS section start. */
  writeBlocksStart(): void {
    this.writeGroupCode(0, 'SECTION');
    this.writeGroupCode(2, 'BLOCKS');
  }

  /** Write the BLOCKS section end. */
  writeBlocksEnd(): void {
    this.writeGroupCode(0, 'ENDSEC');
  }

  /** Write the ENTITIES section start. */
  writeEntitiesStart(): void {
    this.writeGroupCode(0, 'SECTION');
    this.writeGroupCode(2, 'ENTITIES');
  }

  /** Write the ENTITIES section end. */
  writeEntitiesEnd(): void {
    this.writeGroupCode(0, 'ENDSEC');
  }

  /** Write the EOF marker. */
  writeEof(): void {
    this.writeGroupCode(0, 'EOF');
  }

  /** Get the complete DXF string. */
  toString(): string {
    return this.lines.join('\n');
  }
}
