#Sort sore and name of players print the top 10

players = [
    {'name': 'Alice', 'score': 500},
    {'name': 'Bob', 'score': 1200},
    {'name': 'Charlie', 'score': 300},
    {'name': 'Dave', 'score': 800},
    {'name': 'Eve', 'score': 950},
    {'name': 'Frank', 'score': 750},
    {'name': 'Grace', 'score': 660},
    {'name': 'Heidi', 'score': 720},
    {'name': 'Ivan', 'score': 470},
    {'name': 'Judy', 'score': 530},
    {'name': 'Kathy', 'score': 480},
    {'name': 'Leo', 'score': 610},
    {'name': 'Mallory', 'score': 580}
]


players_sorted = sorted(players, key=lambda x: (-x['score'], x['name']))


print("Top 10 players:")
for player in players_sorted[:10]:
    print(f"{player['name']}: {player['score']}")
