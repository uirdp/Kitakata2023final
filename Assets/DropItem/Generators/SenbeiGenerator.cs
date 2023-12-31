using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenbeiGenerator : SakabinGenerator
{
    private static float span;
    private static float freq = 5.0f;

    void Start()
    {
        span = GameOverseer.dropItemSpan - freq;
    }

    void Update()
    {
        //二つ目の蔵登場以降に生成する
        if (GameOverseer.score > KuraConstants.SECOND)
        {
            Generate(span);
            span = UpdateSpan(freq);
            //制限時間を超過したら停止
            if (GameOverseer.isOver) span = 1000000f;

        }
    }
}
