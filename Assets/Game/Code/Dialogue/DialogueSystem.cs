using Assets.Game.Code.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Code.Dialogue
{
    public class DialogueSystem : MonoBehaviour
    {
        public float DelayPerWord = 0.3f;
        private List<LineTalk> listLines;
        private int index = 0;
        private Text text;
        private TextFadeout textFadeout;
        private float cooldown = 0;

        void Start()
        {
            text = GetComponentInChildren<Text>();
            textFadeout = text.GetComponent<TextFadeout>();
        }

        void Update()
        {
            if (cooldown > 0)
            {
                cooldown -= Time.deltaTime;
                if (cooldown <= 0)
                {
                    NextLine();
                }
            }
        }

        public void SetLines(List<LineTalk> lines)
        {
            index = 0;
            listLines = lines;
            if (listLines.Count > 0)
                ShowLine();
        }

        private void NextLine()
        {
            index++;
            if (index < listLines.Count)
            {
                ShowLine();
                
            }
            else
            {
                index = 0;
                cooldown = 0;
            }
            
        }

        private void ShowLine()
        {
            LineTalk lineTalk = listLines[index];
            float timeVisible = GetTimeForString(lineTalk.Line);

            Speaker speaker = lineTalk.Speaker;
            text.text = lineTalk.Line;
            text.color = GetSpeakerColor(lineTalk.Speaker);
            textFadeout.Show(timeVisible);

            cooldown = timeVisible + textFadeout.FadeInDuration + textFadeout.fadeOutDuration + lineTalk.DelayAfter;
        }

        private Color32 GetSpeakerColor(Speaker speaker)
        {
            switch (speaker)
            {
                case Speaker.Bob:
                    return new Color32(255, 255, 255, 255);

                case Speaker.Tortoise:
                    return new Color32(75, 75, 75, 255);
            }
            return new Color32();
        }

        private float GetTimeForString(string name)
        {
            float time = DelayPerWord;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ')
                {
                    time += DelayPerWord;
                }
            }
            return time;
        }
    }
}
