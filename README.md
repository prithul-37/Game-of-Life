# Game of Life - Unity Simulation

This repository contains a Unity-based simulation of **Conway's Game of Life**, a cellular automaton devised by mathematician John Conway. In this simulation, cells evolve over time based on a set of simple rules, resulting in complex, emergent behavior.

## Features

- **Interactive Grid**: Customize the initial state by activating/deactivating cells before starting the simulation.
- **Simulation Controls**: 
  - Play/Pause the simulation.
  - Adjust the speed of evolution.
  - Reset the simulation to the initial state.
- **Classic Rules**: Implements the standard rules of Conway's Game of Life:
  1. Any live cell with fewer than two live neighbors dies (underpopulation).
  2. Any live cell with two or three live neighbors lives on to the next generation.
  3. Any live cell with more than three live neighbors dies (overpopulation).
  4. Any dead cell with exactly three live neighbors becomes a live cell (reproduction).

### Prerequisites

- **Unity**: You need [Unity](https://unity.com/) installed. This project was built using Unity version `X.X.X` (replace with your Unity version).

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/prithul-37/game-of-life-unity.git
    ```

2. Open the project in Unity.

3. Play the simulation by pressing the **Play** button in Unity’s editor.

### Controls

- **Left-click**: Toggle cells between alive and dead.
- **Play/Pause**: Start or stop the simulation.
- **Speed Slider**: Adjust the simulation speed.
- **Reset**: Clear the grid and start over.

## Future Enhancements

- Implement additional patterns such as gliders or oscillators.
- Add different rule sets for variations of the Game of Life.
- Export/import patterns for user sharing.

## Credits

- **John Conway**: Creator of the original Game of Life concept.
- **Your Name**: Developer of this Unity simulation.
