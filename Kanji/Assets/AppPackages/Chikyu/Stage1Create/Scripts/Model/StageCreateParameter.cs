using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Create StageCreateParameter")]
public class StageCreateParameter : ScriptableObject 
{
    public int MeteoCreateSpeedUpTimeSpan;//ステージ用の設定値 //そのステージの全てのMeteoが何秒ごとに生成間隔がアップするか（秒）

    public int MeteoCreateSpeedUpPhase;//ステージ用の設定値 //Meteoが何フェーズ目以降に生成間隔がアップするか（フェーズ）
                                                           //1フェーズ：MeteoCreateSpeedUpTimeSpan秒経過

    public int MeteoCreateSpeedUpSpanShortening;//ステージ用の設定値 //Meteoの生成間隔が何秒早くなるかの値（秒）

    public int LevelUpPhase; //特定のキャラが何フェーズ目以降に生成されるか（フェーズ）
    
}
