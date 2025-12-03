console.log("Day 3: Advent of Code");

import * as fs from 'fs';

const filePath: string = 'data.txt';

function findHighestJoltage(powerBanks: string): number {
    const joltageRatings: number[] = powerBanks.split('').map(Number);
    const joltRatingsSorted = joltageRatings.toSorted((a, b) => b - a);
    let largestJoltageIndex = joltageRatings.findIndex((rating) => rating === joltRatingsSorted[0]);
    if(largestJoltageIndex === joltageRatings.length - 1) largestJoltageIndex = joltageRatings.findIndex((rating) => rating === joltRatingsSorted[1]);
    const restOfArray = joltageRatings.slice(largestJoltageIndex + 1);
    const restOfArraySorted = restOfArray.toSorted((a, b) => b - a);

    return (joltageRatings[largestJoltageIndex] * 10) + restOfArraySorted[0];
}

try {
    const fileContent: string = fs.readFileSync(filePath, 'utf-8');
    const lines: string[] = fileContent.split(/\r?\n/); // Handles both Windows (\r\n) and Unix (\n) line endings

    let total = 0;
    for (const line of lines) {
        console.log(`Processing line: ${line.trim()}`); // Log each line being processed
        if(line.trim() === '') continue; // Skip empty lines
        let highestJoltage = findHighestJoltage(line.trim());
        total += highestJoltage;
    }
    console.log(`Total highest joltage: ${total}`);
} catch (error) {
    if (error instanceof Error) {
        console.error(`Error reading file: ${error.message}`);
    } else {
        console.error('An unknown error occurred.');
    }
}