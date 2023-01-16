using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using HarmonyLib;

namespace CCU {

	public static class InstructionTableBuilder {

		public static string BuildTable(IEnumerable<CodeInstruction> instructions) {
			TextTableBuilder tableBuilder = new TextTableBuilder();
			tableBuilder.Row("Labels", "OpCode", "Operand");
			tableBuilder.ThinRowSeparator();

			foreach (CodeInstruction instruction in instructions) {
				if (instruction.labels.Count > 5) {
					List<List<Label>> labelBatches = GetAsBatches(instruction.labels, 5);
					tableBuilder.ThinRowSeparator();
					tableBuilder.Row(LabelsToString(labelBatches[0]), instruction.opcode.ToString(), OperandToString(instruction.operand));
					for (int i = 1; i < labelBatches.Count; i++) {
						tableBuilder.Row(LabelsToString(labelBatches[i]));
					}
					tableBuilder.ThinRowSeparator();
				} else {
					tableBuilder.Row(LabelsToString(instruction.labels), instruction.opcode.ToString(), OperandToString(instruction.operand));
				}
			}

			tableBuilder.EndTable();
			return tableBuilder.BuildTable("  ");
		}

		private static string LabelsToString(IEnumerable<Label> labels) {
			return string.Join(", ", labels.Select(label => label.GetHashCode()));
		}

		private static List<List<T>> GetAsBatches<T>(IReadOnlyList<T> enumerable, int batchSize) {
			List<List<T>> batches = new List<List<T>>();

			int enumerableCount = enumerable.Count;
			for (int i = 0; i < enumerableCount; i += batchSize) {
				List<T> batch = new List<T>();
				int numAvailableItems = Math.Min(batchSize, enumerableCount - i);
				for (int batchIndex = 0; batchIndex < numAvailableItems; batchIndex++) {
					batch.Add(enumerable[i + batchIndex]);
				}
				batches.Add(batch);
			}

			return batches;
		}

		private static string OperandToString(object operand) {
			if (operand == null) {
				return "null";
			}
			if (operand is Label label) {
				return label.GetHashCode().ToString();
			}
			return operand.ToString();
		}

	}

	public class TextTableBuilder {

		private const int COL_PADDING_LEFT = 1;
		private const int COL_PADDING_RIGHT = 2;
		private static readonly string PADDING_STRING_LEFT = new string(' ', COL_PADDING_LEFT);
		private static readonly string PADDING_STRING_RIGHT = new string(' ', COL_PADDING_RIGHT);

		private readonly List<TableRow> rows = new List<TableRow>();
		private readonly List<int> columnWidths = new List<int>();

		public void Row(params string[] columnText) {
			rows.Add(new TextLine(columnText));
			EnsureColumnWidths(columnText.Length);
			for (int i = 0; i < columnText.Length; i++) {
				columnWidths[i] = Math.Max(columnWidths[i], columnText[i].Length);
			}
		}

		public void ThinRowSeparator() {
			rows.Add(new RowSeparator('-'));
		}

		public void ThickRowSeparator() {
			rows.Add(new RowSeparator('='));
		}

		public void EndTable() {
			rows.Add(new TableEndLine('='));
		}

		public string BuildTable(string tableIndent) {
			int[] colWidthArray = new int[columnWidths.Count];
			for (int i = 0; i < columnWidths.Count; i++) {
				colWidthArray[i] = columnWidths[i];
			}

			StringBuilder builder = new StringBuilder();
			foreach (TableRow row in rows) {
				builder.Append(tableIndent);
				row.Build(builder, colWidthArray);
			}
			return builder.ToString();
		}

		private void EnsureColumnWidths(int numColumns) {
			for (int i = columnWidths.Count; i < numColumns; i++) {
				columnWidths.Add(0);
			}
		}


		private interface TableRow {

			void Build(StringBuilder builder, int[] columnWidths);

		}

		private class RowSeparator : TableRow {

			private const char COL_SEPARATOR_CHAR = '+';

			private readonly char separatorChar;

			public RowSeparator(char separatorChar) {
				this.separatorChar = separatorChar;
			}

			public void Build(StringBuilder builder, int[] columnWidths) {
				string lineSeparatorString = string.Join(
						"" + COL_SEPARATOR_CHAR,
						columnWidths.Select(colWidth => new string(separatorChar, COL_PADDING_LEFT + COL_PADDING_RIGHT + colWidth))
				);
				builder.Append("|").Append(lineSeparatorString).Append("|\n");
			}

		}

		private class TableEndLine : TableRow {

			private readonly char separatorChar;

			public TableEndLine(char separatorChar) {
				this.separatorChar = separatorChar;
			}

			public void Build(StringBuilder builder, int[] columnWidths) {
				int totalWidth = -1; // there are 1 less column separators than columns
				totalWidth += columnWidths.Sum(columnWidth => (COL_PADDING_LEFT + COL_PADDING_RIGHT + columnWidth + 1));
				builder.Append("\\").Append(new string(separatorChar, totalWidth)).Append("/\n");
			}

		}

		private class TextLine : TableRow {

			private readonly string[] columnText;

			public TextLine(string[] columnText) {
				this.columnText = columnText;
			}

			public void Build(StringBuilder builder, int[] columnWidths) {
				for (int i = 0; i < columnWidths.Length; i++) {
					string textContent = i < columnText.Length ? columnText[i] : "";
					builder.Append("|")
							.Append(PADDING_STRING_LEFT)
							.Append(textContent)
							.Append(new string(' ', columnWidths[i] - textContent.Length))
							.Append(PADDING_STRING_RIGHT);
				}
				builder.Append("|\n");
			}

		}

	}

}
