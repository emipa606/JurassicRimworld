# GitHub Copilot Instructions for Jurassic Rimworld (Continued)

## Mod Overview and Purpose
Jurassic Rimworld (Continued) is a mod that integrates the thrilling presence of dinosaurs into your RimWorld experience. Inspired by the iconic Jurassic franchise, this mod not only adds new creatures but also introduces complex systems for breeding, park creation, and combat scenarios. The purpose of this mod is to enrich colony management with prehistoric challenges and wonders, offering a fresh and dynamic twist to traditional gameplay.

## Key Features and Systems
- **Diverse Creature Roster:** Introduces over a hundred prehistoric creatures, including dinosaurs, pterosaurs, synapsids, and invertebrates.
- **Transport and Aesthetics:** Large and medium creatures can serve as pack animals, while jurassic-themed buildings and defenses enhance your base's security.
- **Resource and Construction Systems:** Mine amber, reconstruct DNA at specialized benches, and bring creatures from the past into existence.
- **Modular Options:** Customize creature spawning and reconstruction attributes to suit your gameplay preferences.
- **Additional Elements:** Enjoy unique sounds, music, and much more, designed to immerse you in a prehistoric atmosphere.

**Note:** This mod significantly increases game difficulty, especially at early stages. Reconstructed dinosaurs are generally more tamable, with exceptions like the Indominus species.

## Coding Patterns and Conventions
- **Classes and Methods:** Organized with a clear structure, adhering to C# conventions for naming and access levels.
  - Example: `public class DinosaurSettings : Mod {}` within `DinosaurSettings.cs`.
- **Internal and Public Access:** Utilizes proper access levels to encapsulate logic and expose necessary functionalities.
- **Static Classes:** Used for functionality that does not require instantiation, such as utility methods in `DinosaurManhunterPackIncidentUtility.cs`.

## XML Integration
- **Custom Data Handling:** Utilize XML parsing for custom data setup, as seen in `ThingDefCountWithChanceClass.cs` with `LoadDataFromXmlCustom(XmlNode xmlRoot)`.
- **DefModExtension Use:** Extend default definitions with `TraderKindDefExtension : DefModExtension` to customize in-game entities.

## Harmony Patching
- **Modular Patches:** Implements Harmony patches to alter base game functionality without direct modification.
  - Example: `JR_PawnGroupKindWorker_Trader_GenerateCarriers_Patch` adjusts trader behaviors.
- **Patching Strategy:** Employ selective patches for critical gameplay adjustments, such as dynamic trader and manhunter pack interactions.

## Suggestions for Copilot
- **Code Completion:** Ensure Consistent Naming Conventions - Use CamelCase for method names and PascalCase for class names.
- **Method Suggestions:** When adding new features or extending existing ones, mirror the method patterns seen in the files, such as in `JobDriver_PlayHoloscope.cs`.
- **Enhanced Logic with LINQ:** Suggest efficient data manipulation through LINQ queries, particularly when dealing with collections of custom objects.
- **Regular Expressions for XML:** Recommend regular expression patterns for XML-based data validation and transformation tasks.
- **Testing and Debugging:** Provide insights on testing Harmony patches and proper exception handling methodologies.

With this structured approach, Copilot can assist effectively in extending and maintaining the Jurassic Rimworld mod, promoting consistent code quality and improving modding workflows.
