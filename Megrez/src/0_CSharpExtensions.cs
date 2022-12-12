// CSharpened and further development by (c) 2022 and onwards The vChewing Project (MIT License).
// Was initially rebranded from (c) Lukhnos Liu's C++ library "Gramambular 2" (MIT License).
// ====================
// This code is released under the MIT license (SPDX-License-Identifier: MIT)
#pragma warning disable CS1591

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Megrez {
public static class CSharpExtensions {
  // MARK: - String.Joined (Swift-Style)

  public static string Joined(this IEnumerable<string> self, string? separator = null) {
    if (separator == null || separator.LiteralCount() == 0) {
      StringBuilder output = new();
      foreach (string x in self) output.Append(x);
      return output.ToString();
    }
    return string.Join(separator, self);
  }

  // MARK: - UTF8 String Length

  public static int LiteralCount(this string self) => new StringInfo(self).LengthInTextElements;

  // MARK: - UTF8 String Char Array

  public static List<string> LiteralCharComponents(this string self) {
    List<string> result = new();
    TextElementEnumerator charEnum = StringInfo.GetTextElementEnumerator(self);
    while (charEnum.MoveNext()) result.Add(charEnum.GetTextElement());
    return result;
  }

  // MARK: - Enumerable.IsEmpty()

  public static bool IsEmpty<T>(this List<T> theObject) => theObject.Count == 0;

  // MARK: - Enumerable.Enumerated() (Swift-Style)

  public static IEnumerable<(int index, T item)> Enumerated<T>(this IEnumerable<T> source) =>
      source.Select((item, index) => (index, item));

  // MARK: - List.Reversed() (Swift-Style)
  public static List<T> Reversed<T>(this List<T> self) => self.ToArray().Reverse().ToList();

  // MARK: - Stable Sort Extension

  // Ref: https://stackoverflow.com/a/148123/4162914

  public static void StableSort<T>(this T[] values, Comparison<T> comparison) {
    KeyValuePair<int, T>[] keys = new KeyValuePair<int, T>[values.Length];
    for (int i = 0; i < values.Length; i++) keys[i] = new KeyValuePair<int, T>(i, values[i]);
    Array.Sort(keys, values, new StabilizingComparer<T>(comparison));
  }

  public static List<T> StableSorted<T>(this List<T> values, Comparison<T> comparison) {
    KeyValuePair<int, T>[] keys = new KeyValuePair<int, T>[values.Count()];
    for (int i = 0; i < values.Count(); i++) keys[i] = new KeyValuePair<int, T>(i, values[i]);
    T[] theValues = values.ToArray();
    Array.Sort(keys, theValues, new StabilizingComparer<T>(comparison));
    return theValues.ToList();
  }

  private sealed class StabilizingComparer<T> : IComparer<KeyValuePair<int, T>> {
    private readonly Comparison<T> _comparison;

    public StabilizingComparer(Comparison<T> comparison) { _comparison = comparison; }

    public int Compare(KeyValuePair<int, T> x, KeyValuePair<int, T> y) {
      int result = _comparison(x.Value, y.Value);
      return result != 0 ? result : x.Key.CompareTo(y.Key);
    }
  }
}

// MARK: - Range with Int Bounds

public struct BRange : IEnumerable<int> {
  public Range Range { get; }
  public int Lowerbound { get; }
  public int Upperbound { get; }
  public BRange(int lowerbound, int upperbound) {
    Lowerbound = Math.Min(lowerbound, upperbound);
    Upperbound = Math.Max(lowerbound, upperbound);
    Range = Lowerbound..Upperbound;
  }

  public List<int> ToList() {
    List<int> result = new();
    for (int i = Lowerbound; i < Upperbound; i++) {
      result.Add(i);
    }
    return result;
  }

  public IEnumerable<(int index, int item)> Enumerated() => ToList().Enumerated();

  IEnumerator<int> IEnumerable<int>.GetEnumerator() => ToList().GetEnumerator();

  IEnumerator IEnumerable.GetEnumerator() => ToList().GetEnumerator();
}
}  // namespace Megrez
