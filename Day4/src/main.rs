use std::collections::HashMap;
use std::fs::File;
use std::io::{self, BufRead};

fn load_roles(_contents: Vec<String>) -> HashMap<i32, Vec<i32>> {
    let mut ret: HashMap<i32, Vec<i32>> = HashMap::new();
    ret.clear();
    let mut row_index = 0;
    for line in _contents {
        let mut col_index = 0;
        let row = ret.entry(row_index).or_insert(Vec::new());
        for c in line.chars() {
            if c == '@' {
                row.push(col_index);
            }
            col_index += 1;
        }
        row_index += 1;
    }

    return ret;
}

fn load_file(file_name: &str) -> Vec<String> {
    let file = File::open(file_name).expect("Unable to open file");
    let reader = io::BufReader::new(file);
    let mut contents = Vec::new();
    for line in reader.lines() {
        let line = line.unwrap();
        contents.push(line);
    }
    return contents;
}

fn main() {
    let roll_list = load_file("./src/data.txt");

    let spots = load_roles(roll_list);
    println!("{}", spots.len());
    let mut count = 0;

    for (row_index, col_vals) in spots.iter() {
        for col_val in col_vals {
            let mut total_touching_rolls = 0;
            //check previous row
            if let Some(prev_row) = spots.get(&(*row_index - 1)) {
                for range in col_val - 1..col_val + 2 {
                    if prev_row.contains(&range) {
                        total_touching_rolls += 1;
                    }
                }
            }
            //check current row (previous cell)
            if *col_val > 0 {
                if col_vals.contains(&(*col_val - 1)) {
                    total_touching_rolls += 1;
                }
            }

            //check current row (next cell)
            // Assuming no upper bound check needed for correctness, just existence
            if col_vals.contains(&(*col_val + 1)) {
                total_touching_rolls += 1;
            }

            if let Some(next_row) = spots.get(&(*row_index + 1)) {
                for range in col_val - 1..col_val + 2 {
                    if next_row.contains(&range) {
                        total_touching_rolls += 1;
                    }
                }
            }
            if total_touching_rolls < 4 {
                count += 1;
            }
        }
    }
    println!("count: {}", count);
}
