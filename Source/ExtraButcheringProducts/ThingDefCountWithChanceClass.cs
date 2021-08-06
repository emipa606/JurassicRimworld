using System.Xml;
using Verse;

namespace ExtraButcheringProducts
{
    // Token: 0x02000006 RID: 6
    public sealed class ThingDefCountWithChanceClass
    {
        // Token: 0x04000007 RID: 7
        public float chance;

        // Token: 0x04000006 RID: 6
        public int count;

        // Token: 0x04000005 RID: 5
        public ThingDef thingDef;

        // Token: 0x06000008 RID: 8 RVA: 0x0000220E File Offset: 0x0000040E
        public ThingDefCountWithChanceClass()
        {
        }

        // Token: 0x06000009 RID: 9 RVA: 0x00002218 File Offset: 0x00000418
        public ThingDefCountWithChanceClass(ThingDef thingDef, int count, float chance)
        {
            this.thingDef = thingDef;
            this.count = count;
            this.chance = chance;
        }

        // Token: 0x0600000A RID: 10 RVA: 0x00002238 File Offset: 0x00000438
        public void LoadDataFromXmlCustom(XmlNode xmlRoot)
        {
            if (xmlRoot.ChildNodes.Count != 3)
            {
                Log.Error("Misconfigured ThingDefCountWithChance: " + xmlRoot.OuterXml);
            }
            else
            {
                DirectXmlCrossRefLoader.RegisterObjectWantsCrossRef(this, "thingDef", xmlRoot.FirstChild.InnerText);
                count = (int) ParseHelper.FromString(xmlRoot.ChildNodes[1].InnerText, typeof(int));
                chance = (float) ParseHelper.FromString(xmlRoot.ChildNodes[2].InnerText, typeof(float));
            }
        }
    }
}