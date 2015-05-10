using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class PatternMeshImporter : AssetPostprocessor {

    private static void OnPostprocessAllAssets(string[] importedAssets,
                                               string[] deletedAssets,
                                               string[] movedAssets,
                                               string[] movedFromPath) {
        foreach (string path in importedAssets) {
            string extension = Path.GetExtension(path);

            if (extension == ".patternmesh") {

                string filePath = Path.GetDirectoryName(path);
                string fileName = Path.GetFileNameWithoutExtension(path);
                string file = "";

                List<Vector3> vertices = new List<Vector3>();

                using (StreamReader sr = new StreamReader(path)) {
                    while(!sr.EndOfStream) {
                        string line = sr.ReadLine();
                        string[] tokens = line.Split(new string[]{" "}, System.StringSplitOptions.None);

                        if (tokens[0] == "v") {
                            Vector3 vertex = new Vector3(float.Parse(tokens[1]), float.Parse(tokens[2]), float.Parse(tokens[3]));
                            vertices.Add(vertex);
                        }
                        file += line + "\n";
                    }
                }
                
                Mesh mesh = new Mesh();
                mesh.vertices = vertices.ToArray();

                AssetDatabase.CreateAsset(mesh, filePath + "/" + fileName + ".asset");

                Debug.Log(filePath + "\n" + fileName + "\n" + file);
            }
        }
    }
}
