using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace Gameplay
{
    public class QuestsDispatcher : EditorWindow
    {
        TextAsset questTSV;
        List<string> quests;
        int k;

        [MenuItem("Window/Quests Dispatcher ")]

        public static void Init()
        {
            QuestsDispatcher window = EditorWindow.GetWindow(typeof(QuestsDispatcher)) as QuestsDispatcher;
            // Initialize window : start de la fenêtre

            window.Show();
        }

        private void OnGUI()
        {
            questTSV = EditorGUILayout.ObjectField(questTSV, typeof(TextAsset)) as TextAsset;

            if (questTSV != null)
            {
                

                if (GUILayout.Button("Set Quests"))
                {

                    CutQuestAsset();
                }
            }

        }

        public void CutQuestAsset()
        {
            quests = new List<string>();
            k = 0;
            for (int i = 0; i < questTSV.text.Length; i++)
            {
                int result = 0;
                int.TryParse(questTSV.text[i].ToString(), out  result);
                if (questTSV.text[i] != ';' && result == 0)
                {
                    quests.Add("");
                    quests[k] += questTSV.text[i];

                }
                else 
                {
                    
                    if (k > 1 && quests[k] != "")
                    {
                        QuestContainer questContainer = new QuestContainer();
                        questContainer.quest = quests[k];

                        AssetDatabase.CreateAsset(questContainer, "Assets/Features/Quests/Quests/Quest" + k + ".asset");
                    }

                    k++;
                }

            }
        }

    }
}

