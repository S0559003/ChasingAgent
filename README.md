### Projektbeschreibung

Chasing Game ein einfaches 3D Spiel, in dem zwei Charaktere sich in einem geschlossenen Raum bewegen können. 
Es gibt einen Fänger und eine Beute. Diese Charaktere sind besitzen ein mit Hilfe von Unity ML Agents und dem Tensorflow 
Framework erstelltes Model und sollen folgende Aufgaben erfüllen: 

Der Fänger soll versuchen die Beute zu fangen und die Beute soll so lange wie möglich versuchen nicht gefangen zu werden.

[Code Dokumentation (Doxygen)](https://github.com/S0559003/ChasingAgent/blob/master/docs/html/index.html )

---

### Ähnliche Projekte

---
Folgende Quellen wurden zur Hilfe als Tutorial verwendet, bzw. haben bei der Ideenfindung geholfen:

[Chasing Game](https://www.youtube.com/watch?v=Je-60mOz6O4)

[Unity ML-Agents Tutorial | AI Truffle Pigs!](http://www.immersivelimit.com/tutorials/machine-learning-pig-agents-unity)

[Offizielle Projekt Dokumentation von Unity](https://github.com/Unity-Technologies/ml-agents/tree/master/docs)

### Systembild

---

![Abbildung Systembild Chasing Game](https://github.com/S0559003/ChasingAgent/blob/master/docs/images/Systembild.png "Systembild Chasing Game")

### Installation

Auf Mac und Linux Umgebungen:

https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Installation.md

``Dieses Projekt wurde nur auf Windows getestet!``

For Windows:

https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Installation-Windows.md

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



