using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameController : MonoBehaviour
{

  public static GameController Instance;
  // Start is called before the first frame update
  public bool isTesting = false;
  public GameObject worldTextPrefab;
  public GameObject poofEffectPrefab;
  public GameObject hitEffectPrefab;
  public GameObject bloodPrefeb;
  public List<ParticleSystem> winParticles;

  public GameObject redPanel;
  public GameObject winPanel, losePanel, tutpanel;
  public bool hasPlayedLoseSound =false;
  void Start()
  {
    Instance = this;
    if (isTesting == false)
      LoadStage();

      hasPlayedLoseSound =false;
      AudioController.Play("bgm");

      foreach (var item in winParticles)
      {
          item.Stop();
      }
  }

  // Update is called once per frame
  void Update()
  {

  }
  public void OnHitPlay()
  {
    tutpanel.gameObject.SetActive(false);
  }
  public void ShowTextAt(string message, Vector3 pos = new Vector3(), float scale = 1, Color color = new Color())
  {
    var gameObj = Instantiate(worldTextPrefab, pos, Quaternion.identity);
    gameObj.transform.localScale = gameObj.transform.localScale * scale;
    Text text = gameObj.GetComponentInChildren<Text>();
    if (color == new Color()) color = new Color(0.8f, 0.2f, 0.2f);
    text.color = color;
    text.text = message;
    gameObj.transform.DOMove(new Vector3(pos.x + Random.Range(-1f, 1f), pos.y + Random.Range(-1f, 1f), 0), 1f).OnComplete(() => Destroy(gameObj));
  }

  public void Win()
  {
    AudioController.Play("win");
    winPanel.gameObject.SetActive(true);
    foreach (var item in winParticles)
      {
          item.Play();
      }
  }
  public void Lose()
  {
    if(hasPlayedLoseSound==false){
    AudioController.Play("lose");
    hasPlayedLoseSound =true;
    }

    losePanel.gameObject.SetActive(true);
  }

  public void OnHitReplay()
  {
    SceneManager.LoadScene("GamePlay");
  }
  public void OnHitNextStage()
  {
    DataManager.Instance.stagePlay++;
    if (DataManager.Instance.stagePlay > GameInformation.Instance.stages.Count)
    {
      DataManager.Instance.stagePlay = 1;
    }
    SceneManager.LoadScene("GamePlay");
  }

  public void ShowPoofFx(Vector3 pos, float scale = 1)
  {
    var x = Instantiate(poofEffectPrefab, pos, Quaternion.identity);
    x.transform.localScale *= scale;
    Destroy(x, 1);
  }
  public void ShowHitFx(Vector3 pos, float scale = 1)
  {
    var x = Instantiate(hitEffectPrefab, pos, Quaternion.identity);
    x.transform.localScale *= scale;
    Destroy(x, 1);
  }
    public void ShowBloodFx(Vector3 pos, float scale = 1)
  {
    var x = Instantiate(bloodPrefeb, pos, Quaternion.identity);
    x.transform.localScale *= scale;
    x.transform.eulerAngles = new Vector3(0,0,Random.Range(0,360));
    Destroy(x, 10);
  }
  public void ShowRedPanel()
  {
    redPanel.SetActive(true);
    UnActiveGameObjectAfter(redPanel);
  }
  public void UnActiveGameObjectAfter(GameObject gObject, float sec = 0.2f)
  {
    StartCoroutine(UnActiveAfterCoroutine(gObject, sec));
  }
  IEnumerator UnActiveAfterCoroutine(GameObject gameObject, float sec = 0.2f)
  {
    yield return new WaitForSeconds(sec);
    gameObject.SetActive(false);
  }
  public void LoadStage()
  {
    GameObject stage = Instantiate(GameInformation.Instance.stages[DataManager.Instance.stagePlay - 1], Vector3.zero, Quaternion.identity);
  }
  [ContextMenu("HideWalls")]
  public void HideWalls()
  {
    GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
    foreach (var item in walls)
    {
      item.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    }
  }
  [ContextMenu("ShowWalls")]
  public void ShowWalls()
  {
    GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
    foreach (var item in walls)
    {
      item.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
  }

}
