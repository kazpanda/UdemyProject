//+------------------------------------------------------------------+
//|                                                      hst2csv.mq4 |
//|                                     Copyright (c) 2020, りゅーき |
//|                                           https://autofx100.com/ |
//+------------------------------------------------------------------+
#property copyright "Copyright (c) 2020, りゅーき"
#property link      "https://autofx100.com/"
#property strict
#property show_inputs

//+------------------------------------------------------------------+
//| ライブラリ                                                       |
//+------------------------------------------------------------------+
#include <stderror.mqh>
#include <stdlib.mqh>
#include <WinUser32.mqh>

//+------------------------------------------------------------------+
//| パラメータ                                                       |
//+------------------------------------------------------------------+
extern string InputFileName  = "USDJPY.hst"; // hstファイル名
extern bool   UseFilesFolder = true;         // trueならMQL4\Files、falseならhistory\接続先サーバ

//+------------------------------------------------------------------+
//| Script program start function                                    |
//+------------------------------------------------------------------+
void OnStart()
{
  if(StringSubstr(InputFileName, StringLen(InputFileName) - 3, 3) != "hst"){
    MessageBox("「hstファイル名」パラメータに.hstがありません。", "パラメータ入力エラー", MB_OK|MB_ICONSTOP);
    return;
  }

  int hstHandle;

  if(UseFilesFolder){
    // MQL4\Filesフォルダにあるhstファイル
    hstHandle = FileOpen(InputFileName, FILE_BIN|FILE_READ);
  }else{
    // history\接続先サーバフォルダにあるhstファイル
    hstHandle = FileOpenHistory(InputFileName, FILE_BIN|FILE_READ);
  }

  if(hstHandle < 0){
    MessageBox("hstファイルを開けませんでした。", "hstファイルオープンエラー", MB_OK|MB_ICONSTOP);
    return;
  }

  FileSeek(hstHandle, 68, SEEK_SET);

  string hstSymbol = FileReadString(hstHandle, 12);

  int hstPeriod = FileReadInteger(hstHandle, LONG_VALUE);

  FileSeek(hstHandle, 64, SEEK_CUR);

  string csvFileName = hstSymbol + (string)hstPeriod + ".csv";

  int csvHandle = FileOpen(csvFileName, FILE_CSV|FILE_WRITE, ",");

  if(csvHandle < 0){
    MessageBox("csvファイルを開けませんでした。", "csvファイルオープンエラー", MB_OK|MB_ICONSTOP);
    return;
  }

  MessageBox("hst -> csv 変換開始します。\nこの処理は数分かかります。\n終了時にメッセージが出ますので、チャートを閉じずにお待ちください。", "hst -> csv変換開始");

  while(FileIsEnding(hstHandle) == false){
    datetime barTime   = (datetime)FileReadInteger(hstHandle, LONG_VALUE);
    double   barOpen   = FileReadDouble(hstHandle, DOUBLE_VALUE);
    double   barLow    = FileReadDouble(hstHandle, DOUBLE_VALUE);
    double   barHigh   = FileReadDouble(hstHandle, DOUBLE_VALUE);
    double   barClose  = FileReadDouble(hstHandle, DOUBLE_VALUE);
    double   barVolume = FileReadDouble(hstHandle, DOUBLE_VALUE);

    // 6:土曜日または0:日曜日の場合、スキップ
    if(TimeDayOfWeek(barTime) == 6 || TimeDayOfWeek(barTime) == 0){
      continue;
    }

    FileWrite(csvHandle,
              TimeToString(barTime, TIME_DATE),
              TimeToString(barTime, TIME_MINUTES),
              barOpen,
              barHigh,
              barLow,
              barClose,
              barVolume);
  }

  FileClose(csvHandle);
  FileClose(hstHandle);

  MessageBox("hstファイル → csvファイル変換が終了しました。", "csvファイル変換終了", MB_OK|MB_DEFBUTTON1);
}
