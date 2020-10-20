using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

public class RenameTSV : AssetPostprocessor
{
    
    public static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        if (importedAssets == null) return;

        if (importedAssets.Length == 0) return;

        for (int i = 0; i < importedAssets.Length; i++)
        {
            if (!importedAssets[i].EndsWith(".tsv")) continue;

            string str = importedAssets[i];
            str = str.Substring(0, str.Length - 4);
            str += ".csv";
            File.Move(importedAssets[i],str);        
            File.Move(importedAssets[i]+".meta",str+".meta");

            char separator = ';';
            string content = File.ReadAllText(str);
            content = content.Replace('\t', separator);
            File.WriteAllText(str, content);
    }
}

}
