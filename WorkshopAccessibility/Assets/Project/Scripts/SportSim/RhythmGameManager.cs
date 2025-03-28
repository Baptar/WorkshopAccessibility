using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RhythmGameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] notePrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Sprite[] posesSprites;
    [SerializeField] private Sprite poseBadSprite;
    [SerializeField] private RawImage playerImage;
    [SerializeField] private Transform targetZone;
    [SerializeField] private float noteSpeed = 5f;
    [SerializeField] private float perfectTimingWindow = 0.2f;
    [SerializeField] private float goodTimingWindow = 0.4f;
    [SerializeField] private float missThreshold = -5f;

    private List<GameObject> activeNotes = new List<GameObject>();
    private Dictionary<GameObject, int> noteLanes = new Dictionary<GameObject, int>();
    private int score = 0;
    private int combo = 0;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text scoreText2;
    [SerializeField] private TMP_Text comboText;
    [SerializeField] private TMP_Text comboMaxText;

    [SerializeField] private GameObject perfect;
    [SerializeField] private GameObject good;
    [SerializeField] private GameObject nan;

    private int currentPose = -1;
    private int maxCombo = 0;

    public float actualNoteSpeed;
    void Start()
    {
        actualNoteSpeed = noteSpeed;
        StartCoroutine(SpawnNotes());
    }

    void Update()
    {
        if (UserInput.instance.LeftInput) HandleNotePress(0);
        if (UserInput.instance.RightInput) HandleNotePress(1);
        if (UserInput.instance.UpInput) HandleNotePress(2);
        if (UserInput.instance.DownInput) HandleNotePress(3);

        
        for (int i = activeNotes.Count - 1; i >= 0; i--)
        {
            GameObject note = activeNotes[i];
            note.transform.Translate(Vector3.down * actualNoteSpeed * Time.deltaTime);
            
            if (note.transform.position.y < missThreshold)
            {
                MissNote(note);
            }
        }
    }

    IEnumerator SpawnNotes()
    {
        while (true)
        {
            int index = Random.Range(0, spawnPoints.Length);
            GameObject note = Instantiate(notePrefabs[index], spawnPoints[index].position, Quaternion.identity);
            activeNotes.Add(note);
            noteLanes[note] = index;
            yield return new WaitForSeconds(1f);
        }
    }

    void HandleNotePress(int laneIndex)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.clicQTE);
        foreach (GameObject note in activeNotes)
        {
            if (noteLanes[note] != laneIndex) continue;

            float distance = Mathf.Abs(note.transform.position.y - targetZone.position.y);
            if (distance < perfectTimingWindow)
            {
                StartCoroutine(ShowPerfect());
                Debug.Log("Perfect!");
                AudioManager.instance.PlaySFX(AudioManager.instance.perfect);
                currentPose++;
                if (currentPose >= posesSprites.Length) currentPose = 0;
                    playerImage.texture = posesSprites[currentPose].texture;
                    
                score += 100 * combo;
                combo++;
                if (combo > maxCombo) maxCombo = combo;
                ShowFeedback(note, Color.green);
                DestroyNote(note);
                return;
            }
            if (distance < goodTimingWindow)
            {
                StartCoroutine(ShowGood());
                AudioManager.instance.PlaySFX(AudioManager.instance.good);
                currentPose++;
                if (currentPose >= posesSprites.Length) currentPose = 0;
                    playerImage.texture = posesSprites[currentPose].texture;
                
                Debug.Log("Good!");
                score += 50 * combo;
                combo++;
                if (combo > maxCombo) maxCombo = combo;
                ShowFeedback(note, Color.yellow);
                DestroyNote(note);
                return;
            }
        }
        combo = 0;
        StartCoroutine(ShowNan());
        AudioManager.instance.PlaySFX(AudioManager.instance.miss);
        playerImage.texture = poseBadSprite.texture;
        UpdateUI();
    }

    void MissNote(GameObject note)
    {
        StartCoroutine(ShowNan());
        Debug.Log("Missed!");
        if (playerImage.texture != poseBadSprite.texture)
            AudioManager.instance.PlaySFX(AudioManager.instance.miss);
        playerImage.texture = poseBadSprite.texture;
        combo = 0;
        activeNotes.Remove(note);
        noteLanes.Remove(note);
        Destroy(note);
        UpdateUI();
    }

    void ShowFeedback(GameObject note, Color feedbackColor)
    {
        SpriteRenderer sprite = note.GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = feedbackColor;
            note.transform.localScale *= 1.2f;
        }
    }

    void DestroyNote(GameObject note)
    {
        activeNotes.Remove(note);
        noteLanes.Remove(note);
        Destroy(note, 0.2f);
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        scoreText2.text = score.ToString();
        comboText.text = "Combo: " + combo;
        comboMaxText.text = "Combo max: " + maxCombo;
    }

    private IEnumerator ShowPerfect()
    {
        perfect.SetActive(true);
        yield return new WaitForSeconds(1f);
        perfect.SetActive(false);
    }
    
    private IEnumerator ShowGood()
    {
        good.SetActive(true);
        yield return new WaitForSeconds(1f);
        good.SetActive(false);
    }
    
    private IEnumerator ShowNan()
    {
        nan.SetActive(true);
        yield return new WaitForSeconds(1f);
        nan.SetActive(false);
    }
}