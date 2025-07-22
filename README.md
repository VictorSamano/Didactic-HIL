# Didactic Hardware-in-the-Loop Platform: A Low-Cost Open-Source Approach

**IEEE LATAM Submission ID**: 9619

---

## 👨‍🔬 Authors

- Ing. Shadai Ararita Ojeda Mancera  
- Ing. Jesús Gerardo Carranco Martínez  
- Dr. Víctor Manuel Sámano Ortega  
- Dr. Juan Jose Martínez Nolasco  
- Dr. Coral Martínez Nolasco  
- Dr. Mauro Santoyo Mora

---

## 📁 Included Archives

### [CUT folder](./CUT)

| Subfolder             | Script/File                       | Description                                                               |
|-----------------------|-----------------------------------|---------------------------------------------------------------------------|
| [Ball_Beam_PD_control](./CUT/Ball_Beam_PD_control)  | Ball_Beam_PD_control.ino          | Arduino code implementing a PD controller for the Ball & Beam system      |
| Ball_Beam_P_control   | Ball_Beam_P_control.ino           | Arduino code implementing a P controller for the Ball & Beam system       |
| Gear_Motor_P_control  | Gear_Motor_P_control.ino          | Arduino code implementing a P controller for the Gear Motor system        |
| Motor_PI_control      | Motor_PI_control.ino              | Arduino code implementing a PI controller for the Motor system            |

### [Emulator folder](./Emulator)

| Subfolder     | Scripts                  | Description                                                                 |
|---------------|---------------------------|-----------------------------------------------------------------------------|
| Ball & Beam   | `CMakeLists.txt`, `main.c`| CMake build configuration and source code for Ball & Beam emulator         |
| Gear Motor    | `CMakeLists.txt`, `main.c`| CMake build configuration and source code for Gear Motor emulator          |
| Motor         | `CMakeLists.txt`, `main.c`| CMake build configuration and source code for Motor emulator               |

### [GUI folder](./GUI)

| Subfolder                | Files                                     | Description                                                                 |
|--------------------------|-------------------------------------------|-----------------------------------------------------------------------------|
| Installer                | `HILed.msi`, `setup.exe`                  | Windows installer and setup launcher for HIL emulator                      |
| Visual Studio Project    | `.vs`, `prueba`, `Prueba.sln`             | Visual Studio config/cache, source code, and project files                 |

### [MATLAB Simulations folder](./MATLAB%20simulations)

#### Ball & Beam folder

| Subfolder     | Files                                 | Description                                                                  |
|---------------|----------------------------------------|------------------------------------------------------------------------------|
| control P     | `raiz.m`, `bloques_P.slx`, `data.csv` | MATLAB script, Simulink model with P controller, and captured experimental data |
| control PD    | `raiz.m`, `bloques_PD.slx`, `data.csv`| MATLAB script, Simulink model with PD controller, and captured experimental data |

#### Gear Motor and Motor folder

| Subfolder     | Files                                   | Description                                                                  |
|---------------|------------------------------------------|------------------------------------------------------------------------------|
| Gear Motor    | `raiz.m`, `bloques.slx`, `data.csv`      | MATLAB script, Simulink model, and captured experimental data               |
| Motor         | `raiz.m`, `bloques_motor.slx`, `data.csv`| MATLAB script, Simulink model, and captured experimental data               |

### [PCB folder](./PCB)

| Subfolder         | Script/File Names                                      | Description                                                                 |
|-------------------|--------------------------------------------------------|-----------------------------------------------------------------------------|
| Altium Designer   | `PCB_emuladorHIL_2025-01-22.pcbdoc`, `Sheet_1_2025-01-22.schdoc` | Altium Designer layout and schematic of HIL emulator              |
| EasyEDA           | `PCB_*.json`, `SCH_*.json`                             | PCB layout and schematic in EasyEDA format                                  |
| Gerber.zip        | Various `.DRL`, `.G*` files + `How-to-order-PCB.txt`   | Drill files, Gerber files for PCB layers, and manufacturing instructions    |

---

## 💻 Software Requirements

- Visual Studio Code **1.89.0** or later  
- Visual Studio **2022 17.14.7** or later  
- MATLAB **R2021b** or later  
- Windows **10/11 x64**  
- PICO C SDK **1.5.1** or later ([installation guide](https://www.youtube.com/watch?v=gElPEETEqHI))

---

## 📬 Contact

For questions or replication of results:  
📧 [victor.samano@itcelaya.edu.mx](mailto:victor.samano@itcelaya.edu.mx)
