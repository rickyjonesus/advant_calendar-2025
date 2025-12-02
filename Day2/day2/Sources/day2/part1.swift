// The Swift Programming Language
// https://docs.swift.org/swift-book


import Foundation

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

func isRepeating(str: String) -> Bool {
    
    let length = str.count
    if length % 2 != 0 {
        return false
    }
    let firstHalf = str.prefix(length / 2)
    let secondHalf = str.suffix(length / 2)
    if firstHalf != secondHalf {
        return false
    }


    
    return true
}


@main
struct day2 {
    static func main() {
        print("Hello, world!")



        let tokens = readLinesFromFile(filePath: "./data.txt");
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
