use std::fs::File;
use std::io::{self, BufRead};



struct Spot{
    has_roll: bool,
}

fn load_roles(_contents: Vec<String>) -> Vec<Vec<Spot>> {
    let mut ret: Vec<Vec<Spot>> = vec![vec![]];
    for line in _contents { 
        let mut row = Vec::new();
        for c in line.chars() {
            print!("{} ", c);
            let spot = Spot{
                has_roll: if c == '@' { true } else { false },
            };
            row.push(spot);
        }
        println!("");
        ret.push(row);
    }

    return ret;
}

fn main() {
    let file = File::open("./src/example-data.txt").expect("Unable to open file");
    let reader = io::BufReader::new(file);
    let mut contents = Vec::new();
    for line in reader.lines() {
        let line = line.unwrap();
        contents.push(line);
    }
    
    let spots = load_roles(contents);
    let mut rowIndex = 0;
    let mut availableRolls = 0;
    for row in spots.iter() {

        let mut colIndex = 0;

        for col in row.iter() {
            let mut totalTouchingRolls = 0;
            if(col.has_roll){
            
                //Directly before
                if colIndex > 1 && spots[rowIndex][colIndex - 1].has_roll {
                    totalTouchingRolls += 1;
                 
                }


                //Directly after
                if colIndex < row.len() - 1 && spots[rowIndex][colIndex + 1].has_roll {
                 
                    totalTouchingRolls += 1;
                }
                let beginRange = if colIndex > 1 { colIndex - 1 } else { 1 };
                let endRange = if colIndex < row.len() - 1 { colIndex + 1 } else { row.len() - 1 };
                //Directly Above
                if rowIndex > 1
                {                    
                    for rel in beginRange..endRange {
                        if spots[rowIndex - 1][rel].has_roll {
                            totalTouchingRolls += 1;
                        }
                    }
                }

                //Directly Below
                if rowIndex < spots.len() - 1 {
                    print!("b{}-{}", beginRange, endRange);
                    for rel in beginRange..endRange {

                        if spots[rowIndex + 1][rel].has_roll {
                            totalTouchingRolls += 1;
                        }
                    }
                }

                if totalTouchingRolls < 4{
                    availableRolls += 1;
                }
                if totalTouchingRolls < 4
                {
                    print!("@ ");
                }
                else
                {
                    print!("x ");
                }
                print!("{}", totalTouchingRolls);

            }
            else {
                print!(". ");
            }   
            colIndex += 1;
        }
        println!("");
        rowIndex += 1;

    }

    println!("done {}", availableRolls);
}
