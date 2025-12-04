use std::fs::File;
use std::io::{self, BufRead};



struct Spot{
    _has_roll: bool,
    _adjunct_rolls: Vec<Vec<Spot>>
}
fn load_roles(_contents: Vec<String>) -> Vec<Vec<Spot>> {
    return vec![];
}

fn main() {
    let file = File::open("./src/example-data.txt").expect("Unable to open file");
    let reader = io::BufReader::new(file);
    let mut contents = Vec::new();
    for line in reader.lines() {
        let line = line.unwrap();
        println!("{}", line);
        contents.push(line);
    }
    

    let _spots = load_roles(contents);
    println!("done");
}
