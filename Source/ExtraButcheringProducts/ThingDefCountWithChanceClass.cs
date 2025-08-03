using System.Xml;
using Verse;

namespace ExtraButcheringProducts;

public sealed class ThingDefCountWithChanceClass
{
    public float chance;

    public int count;

    public ThingDef thingDef;

    public ThingDefCountWithChanceClass()
    {
    }

    public ThingDefCountWithChanceClass(ThingDef thingDef, int count, float chance)
    {
        this.thingDef = thingDef;
        this.count = count;
        this.chance = chance;
    }

    public void LoadDataFromXmlCustom(XmlNode xmlRoot)
    {
        if (xmlRoot.ChildNodes.Count != 3)
        {
            Log.Error($"Misconfigured ThingDefCountWithChance: {xmlRoot.OuterXml}");
        }
        else
        {
            DirectXmlCrossRefLoader.RegisterObjectWantsCrossRef(this, "thingDef", xmlRoot.FirstChild.InnerText);
            count = (int)ParseHelper.FromString(xmlRoot.ChildNodes[1].InnerText, typeof(int));
            chance = (float)ParseHelper.FromString(xmlRoot.ChildNodes[2].InnerText, typeof(float));
        }
    }
}