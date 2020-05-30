using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Domain.ValueObjects {

    /// <summary>
    /// MeasureValueのValueObject
    /// 完全コンストラクタパターン
    /// コンストラクタで値を設定後は、値を変更できないようにする
    /// MesureDateに関する処理はすべてここに書く
    /// 問題
    /// クラスは参照型なので、同じ値で比較してイコールにならない（アドレス比較のため）
    /// 解決のためValueObject基底抽象クラスを継承してEqualsCoreを実装する
    /// </summary>
    public sealed class MeasureValue : ValueObject<MeasureValue> {

        /// コンストラクタ 
        public MeasureValue(float value) {
            Value = value;
        }

        // getのみ
        public float Value { get; }

        /// <summary>
        /// イコールイコール問題解消
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected override bool EqualsCore(MeasureValue other) {
            return this.Value == other.Value;
        }

        // ビジネスロジック処理があればここに書く
        // この例は、表示の制御（℃表示）
        public string DisplayValue => Math.Round(Value, 2) + "℃";



    }
}
