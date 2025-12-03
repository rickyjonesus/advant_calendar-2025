console.log("Day 3: Advent of Code");

import * as fs from 'fs';

const filePath: string = 'example-data.txt';

try {
    const fileContent: string = fs.readFileSync(filePath, 'utf-8');
    const lines: string[] = fileContent.split(/\r?\n/); // Handles both Windows (\r\n) and Unix (\n) line endings

    for (const line of lines) {
        console.log(line.trim()); // Process each line, trimming whitespace
    }
} catch (error) {
    if (error instanceof Error) {
        console.error(`Error reading file: ${error.message}`);
    } else {
        console.error('An unknown error occurred.');
    }
}