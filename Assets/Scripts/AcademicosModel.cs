using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AcademicosModel", menuName = "AXR-UCN/Academico", order = 0)]
public class AcademicosModel : ScriptableObject {
    public new string name;
    public new string grado;
    public new string email;
    public new string areaDisciplinar;
    public Sprite fotoPerfil;
    public new bool researchGate;//this person has a researchgate link?
    public new string RGInfo;//research gate info

    public new bool googleScholar;
    public new string GSInfo;//google Scholar info

    public new bool externalLinks;
    public string[] ELInfo;//EXTERNAL LINK INFO, THIS IS FOR LEGER AND HIS PERSONAL WEBSITES Xd
}
