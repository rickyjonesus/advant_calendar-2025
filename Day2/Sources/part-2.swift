// The Swift Programming Language
// https://docs.swift.org/swift-book

import Foundation


extension String {
    subscript(_ range: CountableRange<Int>) -> String {
        let start = index(startIndex, offsetBy: max(0, range.lowerBound))
        let end = index(start, offsetBy: min(self.count - range.lowerBound, 
                                             range.upperBound - range.lowerBound))
        return String(self[start..<end])
    }

    subscript(_ range: CountablePartialRangeFrom<Int>) -> String {
        let start = index(startIndex, offsetBy: max(0, range.lowerBound))
         return String(self[start...])
    }
}


func isPrime(_ number: Int) -> Bool {
    // Prime numbers must be greater than 1.
    guard number > 1 else {
        return false
    }

    // 2 is the only even prime number.
    if number == 2 {
        return true
    }

    // Even numbers greater than 2 are not prime.
    if number % 2 == 0 {
        return false
    }

    // Check for divisibility by odd numbers from 3 up to the square root of the number.
    // We only need to check up to the square root because if a number has a divisor greater
    // than its square root, it must also have a divisor smaller than its square root.
    let limit = Int(Double(number).squareRoot())
    for i in stride(from: 3, through: limit, by: 2) {
        if number % i == 0 {
            return false // Found a divisor, so it's not prime.
        }
    }

    // If no divisors were found, the number is prime.
    return true
}

func allTheSameArray<T: Equatable>(array: [T]) -> Bool {
    if let firstElement = array.first {
        let allSame = array.allSatisfy { $0 == firstElement }
        return allSame
    }
    return true
}

func isRepeating(str: String) -> Bool {

    if(str.count == 1) {return false};
    
    //prime length numbers cannot repeat, except 2
    if(str.count != 2 && isPrime(str.count)) {
        return allTheSameArray(array: Array(str))
    }

    for segmentLength in 1...str.count/2 {
        if str.count % segmentLength == 0 { 
            var tokens: [String] = []
            for j in stride(from: 0, to: str.count, by: segmentLength) {
                let startIndex = str.index(str.startIndex, offsetBy: j)
                let endIndex = str.index(startIndex, offsetBy: segmentLength)
                let segmentRange = startIndex..<endIndex
                let segment = String(str[segmentRange])
               // print("Segment: \(segment)")
                tokens.append(segment)
            }  
            if allTheSameArray(array: tokens) {
                return true
            }
        }
    }

    return false
}

func readLinesFromFile(filePath: String) -> [String]? {
    do {
        // Create a URL for the file path
        let fileURL = URL(fileURLWithPath: filePath)

        // Read the entire content of the file into a String
        let fileContents = try String(contentsOf: fileURL, encoding: .utf8)

        // Split the string into an array of lines based on newline characters
        let lines = fileContents.components(separatedBy: ",")

        // Filter out any empty strings that might result from trailing newlines
        return lines.filter { !$0.isEmpty }
    } catch {
        print("Error reading file: \(error)")
        return nil
    }
}

@main
struct part2 {
    static func main() {

        let tokens = readLinesFromFile(filePath: "example-data.txt")
        if let lines = tokens {
            var total = 0
            for line in lines {
                let parts = line.components(separatedBy: "-")
                let start = Int(parts[0])!
                let end = Int(parts[1])!
                for i in start...end {
                    let str = String(i)
                    if isRepeating(str: str) {
                        total = total + i
                        print("\(i) is repeating")
                    }
                }
            }
            print("Total: \(total)")
        }

    }
}
