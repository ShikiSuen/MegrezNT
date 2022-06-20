﻿// CSharpened by (c) 2022 and onwards The vChewing Project (MIT-NTL License).
// Rebranded from (c) Lukhnos Liu's C++ library "Gramambular" (MIT License).
/*
Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

1. The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

2. No trademark license is granted to use the trade names, trademarks, service
marks, or product names of Contributor, except as required to fulfill notice
requirements above.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;

namespace Megrez {
/// <summary>
/// 雙元圖。
/// </summary>
public struct Bigram {
  /// <summary>
  /// 初期化一筆「雙元圖」。一筆雙元圖由一組前述鍵值配對、一組當前鍵值配對、與一筆權重數值組成。
  /// </summary>
  /// <param name="KeyValuePreceded">前述鍵值。</param>
  /// <param name="KeyValue">當前鍵值。</param>
  /// <param name="Score">權重（雙精度小數）。</param>
  public Bigram(KeyValuePair KeyValuePreceded, KeyValuePair KeyValue, double Score) {
    this.KeyValuePreceded = KeyValuePreceded;
    this.KeyValue = KeyValue;
    this.Score = Score;
  }

  /// <summary>
  /// 前述鍵值。
  /// </summary>
  public KeyValuePair KeyValuePreceded { get; set; }
  /// <summary>
  /// 當前鍵值。
  /// </summary>
  public KeyValuePair KeyValue { get; set; }
  /// <summary>
  /// 權重。
  /// </summary>
  public double Score { get; set; }

  public override bool Equals(object Obj) {
    return Obj is Bigram Bigram &&
           EqualityComparer<KeyValuePair>.Default.Equals(KeyValuePreceded, Bigram.KeyValuePreceded) &&
           EqualityComparer<KeyValuePair>.Default.Equals(KeyValue, Bigram.KeyValue) && Score == Bigram.Score;
  }

  public override int GetHashCode() { return HashCode.Combine(KeyValuePreceded, KeyValue, Score); }

  public override string ToString() => $"({KeyValuePreceded}|{KeyValue},{Score})";

  public static bool operator ==(Bigram Lhs, Bigram Rhs) {
    return Lhs.KeyValuePreceded == Rhs.KeyValuePreceded && Lhs.KeyValue == Rhs.KeyValue && Lhs.Score == Rhs.Score;
  }

  public static bool operator !=(Bigram Lhs, Bigram Rhs) {
    return Lhs.KeyValuePreceded != Rhs.KeyValuePreceded || Lhs.KeyValue != Rhs.KeyValue || Lhs.Score != Rhs.Score;
  }

  public static bool operator<(Bigram Lhs, Bigram Rhs) {
    return Lhs.KeyValuePreceded < Rhs.KeyValuePreceded || Lhs.KeyValue < Rhs.KeyValue ||
           Lhs.KeyValue == Rhs.KeyValue && Lhs.Score < Rhs.Score;
  }

  public static bool operator>(Bigram Lhs, Bigram Rhs) {
    return Lhs.KeyValuePreceded > Rhs.KeyValuePreceded || Lhs.KeyValue > Rhs.KeyValue ||
           Lhs.KeyValue == Rhs.KeyValue && Lhs.Score > Rhs.Score;
  }

  public static bool operator <=(Bigram Lhs, Bigram Rhs) {
    return Lhs.KeyValuePreceded <= Rhs.KeyValuePreceded || Lhs.KeyValue <= Rhs.KeyValue ||
           Lhs.KeyValue == Rhs.KeyValue && Lhs.Score <= Rhs.Score;
  }

  public static bool operator >=(Bigram Lhs, Bigram Rhs) {
    return Lhs.KeyValuePreceded >= Rhs.KeyValuePreceded || Lhs.KeyValue >= Rhs.KeyValue ||
           Lhs.KeyValue == Rhs.KeyValue && Lhs.Score >= Rhs.Score;
  }
}
}