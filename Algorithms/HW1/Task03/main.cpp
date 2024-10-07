#include <iostream>

std::string Unpack(std::string packed) {
  std::string s;
  int i = 0;
  while (i != packed.length()) {
    char c = packed[i];
    if (std::isdigit(c) && packed[i + 1] == '[') {
      std::string another_packed;
      int m = (int)c - '0';
      i += 2;
      int brackets_counter = 0;
      while (brackets_counter != 0 || packed[i] != ']') {
        if (packed[i] == '[') {
          brackets_counter++;
        } else if (packed[i] == ']') {
          brackets_counter--;
        }
        another_packed += packed[i];
        i++;
      }
      i++;
      std::string another_unpacked = Unpack(another_packed);
      for (int _ = 0; _ < m; _++) {
        s += another_unpacked;
      }
    } else {
      s += c;
      i++;
    }
  }
  return s;
}


int main() {
  std::string input;
  getline(std::cin, input);
  std::cout << Unpack(input);
}
