using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // キューブの移動速度
    private float speed = -12;
    // 消滅位置
    private float deadLine = -10;

    // AudioSourceコンポーネントを入れる変数(課題)
    private AudioSource audioSource;
    // 音声ファイルを入れるための変数(課題)
    public AudioClip cubeSound;

    // Start is called before the first frame update
    void Start()
    {
        // AudioSourceコンポーネントを取得
        this.audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    // 衝突したスプライトのTagを識別して効果音を鳴らす(課題)
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CubeTag" || collision.gameObject.tag == "GroundTag")
        {
            audioSource.PlayOneShot(cubeSound);
        }
    }
}
