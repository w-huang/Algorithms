import json
import matplotlib.pyplot as plt


easy50 = [1, 121, 953, 206, 20, 53, 415, 21, 7, 155, 176, 234, 88, 937, 125, 14, 453, 811, 283, 412, 680, 509, 706, 9, 67, 13, 203, 387, 202, 543, 1480, 169, 70, 175, 226, 572, 344, 101, 118, 346, 716, 724, 359, 733, 278, 1413, 122, 938, 204, 160]

medium50 = [146, 91, 200, 2, 56, 238, 5, 3, 253, 1396, 221, 380, 973, 1041, 139, 15, 394, 981, 560, 547, 443, 1010, 1197, 17, 54, 215, 22, 347, 528, 79, 695, 763, 49, 31, 1348, 1428, 33, 322, 739, 1209, 518, 692, 92, 46, 1472, 152, 48, 767, 105, 236]

hard50 = [42, 829, 68, 1335, 273, 4, 1192, 127, 239, 295, 312, 224, 10, 588, 420, 41, 1235, 460, 76, 297, 780, 269, 85, 124, 25, 1531, 45, 759, 1383, 128, 140, 37, 871, 301, 741, 749, 23, 1163, 115, 84, 158, 1220, 72, 843, 44, 403, 1326, 212, 363, 920]

with open("topics.json", 'r') as f:
    data = f.read()

topics = json.loads(data)["topics"]

resultE = {}
resultM = {}
resultH = {}
resultT = {}

for topic in topics:
    resultE[topic["name"]] = 0    
    resultM[topic["name"]] = 0    
    resultH[topic["name"]] = 0    
    resultT[topic["name"]] = 0    

for q in easy50:
    for topic in topics:
        if q in topic["questions"]:
            resultE[topic["name"]] = resultE[topic["name"]] + 1
            resultT[topic["name"]] = resultT[topic["name"]] + 1

for q in medium50:
    for topic in topics:
        if q in topic["questions"]:
            resultM[topic["name"]] = resultM[topic["name"]] + 1
            resultT[topic["name"]] = resultT[topic["name"]] + 1

for q in hard50:
    for topic in topics:
        if q in topic["questions"]:
            resultH[topic["name"]] = resultH[topic["name"]] + 1
            resultT[topic["name"]] = resultT[topic["name"]] + 1

plt.figure(1)
plt.title("Distribution Total")
plt.barh(range(len(resultT)), list(resultT.values()), align='center')
plt.yticks(range(len(resultT)), list(resultT.keys()))
plt.tight_layout()

plt.figure(2)
plt.title("Easy Distribution")
plt.barh(range(len(resultE)), list(resultE.values()), align='center', color='green')
plt.yticks(range(len(resultE)), list(resultE.keys()))
plt.tight_layout()

plt.figure(3)
plt.title("Medium Distribution")
plt.barh(range(len(resultM)), list(resultM.values()), align='center', color='orange')
plt.yticks(range(len(resultM)), list(resultM.keys()))
plt.tight_layout()

plt.figure(4)
plt.title("Hard distribution")
plt.barh(range(len(resultH)), list(resultH.values()), align='center', color='red')
plt.yticks(range(len(resultH)), list(resultH.keys()))
plt.tight_layout()

plt.show()

print(resultT)
