
with open("test-data.txt", "r") as file:
    current_position = 50
    numberOfZeros = 0
    for line in file:
        cleanValue = line.strip()
        direction = cleanValue[0]
        distance = int(cleanValue[1:])
        if(direction == 'L'):
            current_position = current_position-distance
        elif(direction == 'R'):
            current_position = current_position+distance
        else:
            raise ValueError("Invalid direction character. Must be 'L' or 'R'.")
        
        current_position = current_position % 100
        if(current_position == 0):
            numberOfZeros += 1
        print(f"Direction: {direction}, Distance: {distance}")
        print(f"Current Position: {current_position}")
    print(f"Number of times position was zero: {numberOfZeros}")