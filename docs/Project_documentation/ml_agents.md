#Projekt Dokumentation KI in Robotik

* Modul: Spezielle Anwendungen der Informatik - KI in der Robotik  (Wintersemester 18/19)
* Student: Ali Bektas - S0559003
* Betreuer: Patrick Baumann

---

### Projektbeschreibung

Chasing Game ist ein Projekt welches zwei Charaktere mit gegensätzlichen Verhalten, jeweils mit künstlicher 
Intelligenz steuert. 

Dabei gibt es einen Charakter welches  

[Quellcode Dokumenttion mit Doxygen](https://github.com/S0559003/ChasingAgent/blob/master/docs/html/index.html )

---

### Ähnliche Projekte und Quellen

---
Folgende Quellen wurden als Hilfe zur Idenfindung und als Tutorials verwendet:

[Chasing Game](https://www.youtube.com/watch?v=Je-60mOz6O4)

[Unity ML-Agents Tutorial | AI Truffle Pigs!](http://www.immersivelimit.com/tutorials/machine-learning-pig-agents-unity)

[Offizielle Projekt Dokumentation von Unity](https://github.com/Unity-Technologies/ml-agents/tree/master/docs)


### Systembild

---

![Abbildung Systembild Chasing Game](https://github.com/S0559003/ChasingAgent/blob/master/docs/images/Systembild.png "Systembild Chasing Game")

### Verwendete Tools und Technologien

  Python / Tensor Flow / Anaconda
    
  - Hyperparameter
  - Tensor Board
  
  Unity / C#

- Brain / Training Area / Academy
    - Player Brain / Learning Brain (Heuristic Brain wäre auch möglich gewesen) 
- TensorSharpPlugin

### Setup in Unity

---

* Brains

    * Vector Observaion Space:
    ...
    * Vector Action Space:
        - Space Type: Continuous
    
* Agents

    * Initialize
    * Reset
    * Done

* Academy

* Area

### Setup in TensorFlow

---

* trainer_config.yaml

* Verwendete Funktion:
    
    Proximal Policy Optimization (PPO)
    
    ![Abbildung PPO](https://github.com/S0559003/ChasingAgent/tree/master/docs/images/PPO.png "Abbildung PPO")
    
* Hyperparameter

* Tensor Board    

### Ausführung

---


```
C:\master\MLAgents\ChasingAgent>activate ml-agents

(ml-agents) C:\master\MLAgents\ChasingAgent>
```

```
(ml-agents) C:\master\MLAgents\ChasingAgent>mlagents-learn config\trainer_config.yaml --run-id=TestWith3Area --train


                        ▄▄▄▓▓▓▓
                   ╓▓▓▓▓▓▓█▓▓▓▓▓
              ,▄▄▄m▀▀▀'  ,▓▓▓▀▓▓▄                           ▓▓▓  ▓▓▌
            ▄▓▓▓▀'      ▄▓▓▀  ▓▓▓      ▄▄     ▄▄ ,▄▄ ▄▄▄▄   ,▄▄ ▄▓▓▌▄ ▄▄▄    ,▄▄
          ▄▓▓▓▀        ▄▓▓▀   ▐▓▓▌     ▓▓▌   ▐▓▓ ▐▓▓▓▀▀▀▓▓▌ ▓▓▓ ▀▓▓▌▀ ^▓▓▌  ╒▓▓▌
        ▄▓▓▓▓▓▄▄▄▄▄▄▄▄▓▓▓      ▓▀      ▓▓▌   ▐▓▓ ▐▓▓    ▓▓▓ ▓▓▓  ▓▓▌   ▐▓▓▄ ▓▓▌
        ▀▓▓▓▓▀▀▀▀▀▀▀▀▀▀▓▓▄     ▓▓      ▓▓▌   ▐▓▓ ▐▓▓    ▓▓▓ ▓▓▓  ▓▓▌    ▐▓▓▐▓▓
          ^█▓▓▓        ▀▓▓▄   ▐▓▓▌     ▓▓▓▓▄▓▓▓▓ ▐▓▓    ▓▓▓ ▓▓▓  ▓▓▓▄    ▓▓▓▓`
            '▀▓▓▓▄      ^▓▓▓  ▓▓▓       └▀▀▀▀ ▀▀ ^▀▀    `▀▀ `▀▀   '▀▀    ▐▓▓▌
               ▀▀▀▀▓▄▄▄   ▓▓▓▓▓▓,                                      ▓▓▓▓▀
                   `▀█▓▓▓▓▓▓▓▓▓▌
                        ¬`▀▀▀█▓


INFO:mlagents.trainers:{'--curriculum': 'None',
 '--docker-target-name': 'None',
 '--env': 'None',
 '--help': False,
 '--keep-checkpoints': '5',
 '--lesson': '0',
 '--load': False,
 '--no-graphics': False,
 '--num-runs': '1',
 '--run-id': 'TestWith3Area',
 '--save-freq': '50000',
 '--seed': '-1',
 '--slow': False,
 '--train': True,
 '--worker-id': '0',
 '<trainer-config-path>': 'config\\trainer_config.yaml'}
INFO:mlagents.envs:Start training by pressing the Play button in the Unity Editor.
```
    
### Mögliche Erweiterung/ Verbesserung

---



