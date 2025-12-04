console.log("Day 3: Advent of Code");

import * as fs from 'fs';

const filePath: string = 'data.txt';

function findHighestJoltageTwo(powerBanks: string): number {
    const joltageRatings: number[] = powerBanks.split('').map(Number);
    const joltRatingsSorted = joltageRatings.toSorted((a, b) => b - a);
    let largestJoltageIndex = joltageRatings.findIndex((rating) => rating === joltRatingsSorted[0]);
    if(largestJoltageIndex === joltageRatings.length - 1) largestJoltageIndex = joltageRatings.findIndex((rating) => rating === joltRatingsSorted[1]);
    const restOfArray = joltageRatings.slice(largestJoltageIndex + 1);
    const restOfArraySorted = restOfArray.toSorted((a, b) => b - a);

    return (joltageRatings[largestJoltageIndex] * 10) + restOfArraySorted[0];
}

function findHighestJoltage12(powerBanks: string): number {
    const joltageRatings: number[] = powerBanks.split('').map(Number);


   // const joltRatingsSorted = joltageRatings.toSpliced(joltageRatings.length -12, 12).toSorted((a, b) => b - a);
    //let largestJoltageIndex = joltageRatings.findIndex((rating) => rating === joltRatingsSorted[0]);
    //let workingDataSet = joltageRatings.toSpliced(0, largestJoltageIndex);
    while(joltageRatings.length > 12) {
        for(let index=0; index < joltageRatings.length; index++) {
            if(index === joltageRatings.length - 1) 
            {
                joltageRatings.splice(index, 1);
            }
            if(joltageRatings[index] <  joltageRatings[index + 1]) {
                joltageRatings.splice(index, 1);
                break;
            }
            if(joltageRatings.length <= 12) break;
        }
    }
    return Number(joltageRatings.join(''));
}

try {
    const fileContent: string = fs.readFileSync(filePath, 'utf-8');
    const lines: string[] = fileContent.split(/\r?\n/); // Handles both Windows (\r\n) and Unix (\n) line endings

    let part2total = 0;
    let part1total = 0;
    for (const line of lines) {
        console.log(`Processing line: ${line.trim()}`); // Log each line being processed
        if(line.trim() === '') continue; // Skip empty lines
        part2total += findHighestJoltage12(line.trim());

        part1total += findHighestJoltageTwo(line.trim());
    }
    console.log(`Total highest joltage (Part 2): ${part2total}`);
    console.log(`Total highest joltage (Part 1): ${part1total}`);
} catch (error) {
    if (error instanceof Error) {
        console.error(`Error reading file: ${error.message}`);
    } else {
        console.error('An unknown error occurred.');
    }
}