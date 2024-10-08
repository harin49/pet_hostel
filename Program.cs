// See https://aka.ms/new-console-template for more information

using menuNamespace;
using petBoardingNameSpace;

int maxPets = 6;

petBoarding pb = new petBoarding(maxPets);

pb.setInitialValues();

Menu.ShowMenuOptions();
Menu.GetMenuSelectionFromUser();
await Menu.ProcessMenuSelection(pb);





