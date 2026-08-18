# ApocaTruck

## Game Overview
ApocaTruck is a roguelike resource-management game where you drive a truck across a post-apocalyptic wasteland because somebody still has to deliver stuff. Along the way, you'll manage fuel, truck condition, and cargo while dealing with random events, bad weather, and the occasional bandit trying to ruin your day.
The goal is to reach the final safe zone with your cargo still intact. If your fuel runs out, your truck breaks down, or you lose all your cargo, the run is over. The road is dangerous, but at least nobody expects next-day delivery anymore.

## How to Run
- Extract the rar files
- run ApocaTruck.exe
- Play

- Engine & version used: Unity 6000.0.57f1
- Build location: [check releases](https://github.com/noveriansoft/BumiGameRoguelike/releases/tag/game)

## Technical Decisions
I used a simple manager-based structure to keep the project organized and easy to expand. Events and upgrades use ScriptableObjects so I can add content without touching code. For procedural variation, events are selected randomly and some choices have RNG-based success/failure outcomes. I focused on resource management and event-driven gameplay since those are the main requirements, so I intentionally skipped more complex systems like combat, AI, inventory, or save/load features to keep the scope realistic for the time limit.

## What I Would Do With More Time
Maybe add more events, i even want to add special animation for every event but i can't animate. implementing consequences system like if we decide to do specific events, it will affect our run in the future and add multiple endings.

## Known Issues
I don't know honestly, everytime i test my game, it doesn't have bugs but when other people test it, it has bunch of bugs, so yeah.
