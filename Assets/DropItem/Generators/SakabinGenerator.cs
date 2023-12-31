using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakabinGenerator : StoneGenerator
{
    private static float span;
    private static float freq = 2.0f;

    public static bool isActivate; //すぎだまをとるとオン

    private int cnt = 0;

    void Start()
    {
        span = GameOverseer.dropItemSpan - freq;
        isActivate = false;
    }

    //時間経過による生成頻度の更新
    public float UpdateSpan(float freq)
    {
        float newSpan = GameOverseer.dropItemSpan - freq * 0.8f;
        if (newSpan <= DropItemConstants.MINSPAN) newSpan = DropItemConstants.MINSPAN;

        return newSpan;
    }

    void Update()
    {
        //3つ目の蔵登場以降に生成する
        if (GameOverseer.score > KuraConstants.THIRD)
        {
            
            //杉球をとると生成間隔が縮まる           
            if (isActivate)
            {
                span = 0.1f;
                cnt++;
                if (cnt >= 400) isActivate = false;
            }

            else span = UpdateSpan(freq);
            Generate(span);

        }
    }
}
