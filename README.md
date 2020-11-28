# Machine Learning Jumper Exercise Tutorial

## Inhoudsopgave

1. [Inleiding](#inleiding)
2. [Benodigdheden](#benodigdheden)
3. [Opzet](#opzet)
4. [Objecten](#objecten)
5. [Scripts](#scripts)
6. [Beloningsysteem](#beloningsysteem)
7. [Training](#training)

## 1. Inleiding

De jumper oefening bestaat uit een speler en auto's die op de speler komen afgereden. Het is de bedoeling dat de speler de auto's ontwijkt door te springen. Als de speler de auto aanraakt, krijgt hij minpunten. De speler wordt getraind om de auto's te ontwijken. De auto's hebben altijd een variabele snelheid. Dit zorgt ervoor dat het spel nog moeilijker wordt voor de speler. In deze tutorial wordt uitgelegd hoe dit project in elkaar zit. Alle objecten, scripts en instellingen worden beschreven. De tutorial legt uit hoe het mogelijk is om deze oefening te reproduceren. Het project en de documentatie is gemaakt door Bram Van Cronenburg en Kristof De Winter.

| Naam                | Studentnummer |
|:-------------------:|:-------------:|
| Kristof De Winter   | s106749       |
| Bram Van Cronenburg | s109544       |

## 2. Benodigdheden

De benodigde programma's om dit project te maken zijn [Visual Studio Community](https://visualstudio.microsoft.com/vs/community/) en [Unity](https://store.unity.com/download). Dit project is gemaakt in Unity versie 2019.4.12f1. Om de agent te trainen wordt [ML-Agents](https://github.com/Unity-Technologies/ml-agents/releases) gebruikt. De versie van ML-Agents die wordt gebruikt is 1.0.5.

[Python](https://www.python.org/downloads/) is vereist om de agent te laten trainen. De aanbevolen versie van Python is 3.8.1 of hoger. Het is optioneel om [Anaconda](https://www.anaconda.com/) of [Miniconda](https://docs.conda.io/en/latest/miniconda.html) te installeren, dit zorgt ervoor dat de training kan worden uitgevoerd in een afgezonderde omgeving.

## 3. Opzet

![Opzet Project](Images/OpzetProject.PNG)

De groene kubus is de speler, de speler kan niet bewegen en kan enkel naar boven springen. De rode kubus is de auto die de speler moet ontwijken. Het grijze vlak is de straat waar de speler en de auto opstaan. De gele rechthoek is de car destroyer, dit zorgt ervoor dat de auto's die de speler ontweken heeft verdwijnen.

Het environment object 

## 4. Objecten

### 4.1 Environment

Het environment is een leeg object waar we alle andere objecten insteken. Hier komt ook het [Environment script]() in.
Hiervan maken we ook een prefab zodat bij het leren er meerdere environments kunnen gebruikt worden. 

### 4.2 

## 5. Scripts

### 5.1 Environment

## 6. Beloningsysteem

## 7. Training

