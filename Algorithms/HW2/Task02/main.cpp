#include <iostream>
#include "vector"

void TrimZeroes(std::string &num) {
  while (num[0] == '0' && num.size() > 1) {
    num = num.substr(1, num.size() - 1);
  }
}

std::string MultiplyByPowerOf10(std::string num, size_t pow) {
  return num + std::string(pow, '0');
}


std::string Add(std::string num1, std::string num2) {
  if (num1.size() > num2.size()) {
    num2 = std::string(num1.size() - num2.size(), '0') + num2;
  } else if (num2.size() > num1.size()) {
    num1 = std::string(num2.size() - num1.size(), '0') + num1;
  }
  std::string res;
  int i = static_cast<int>(num1.size() - 1);
  int k = 0;
  while (i >= 0 || k > 0) {
    if (i < 0) {
      res += std::to_string(k % 10);
      k = k / 10;
    } else {
      int a = num1[i] - '0';
      int b = num2[i] - '0';
      int r = a + b + k;
      res += std::to_string(r % 10);
      k = r / 10;
    }
    i--;
  }
  std::reverse(res.begin(), res.end());
  return res;
}

std::string Subtract(std::string num1, std::string num2) {
  if (num1.size() > num2.size()) {
    num2 = std::string(num1.size() - num2.size(), '0') + num2;
  } else if (num2.size() > num1.size()) {
    num1 = std::string(num2.size() - num1.size(), '0') + num1;
  }
  std::string res;
  int i = num1.size() - 1;
  int k = 0;
  while (i >= 0) {
    int a = num1[i] - '0';
    int b = num2[i] - '0';
    int r = a - b - k;
    k = 0;
    if (r < 0) {
      k++;
      r+=10;
    }
    res += std::to_string(r);
    i--;
  }
  std::reverse(res.begin(), res.end());
  TrimZeroes(res);
  if (k > 0) {
    return "-" + Subtract(MultiplyByPowerOf10("1", num1.size()), res);
  }
  return res;
}

std::string MultiplyClassic(std::string &num1, std::string &num2) {
  std::string min;
  std::string max;
  if (num1.size() <= num2.size()) {
    min = num1;
    max = num2;
  } else {
    min = num2;
    max = num1;
  }
  std::string final;
  for (int i = 0; i < min.size(); i++) {
    std::string res;
    int k = 0;
    for (int j = 0; j < max.size(); j++) {
      int a = min[min.size() - i - 1] - '0';
      int b = max[max.size() - j - 1] - '0';
      res += std::to_string((a * b + k) % 10);
      k = (a * b + k) / 10;
    }
    if (k != 0) res += std::to_string(k);
    std::reverse(res.begin(), res.end());
    final = Add(final, MultiplyByPowerOf10(res, i));
  }
  return final;
}

std::string Multiply(std::string num1, std::string num2) {
  const int threshold = 8;
  if (num1.size() > num2.size()) {
    num2 = std::string(num1.size() - num2.size(), '0') + num2;
  } else if (num2.size() > num1.size()) {
    num1 = std::string(num2.size() - num1.size(), '0') + num1;
  }
  if (num1.size() < threshold || num2.size() < threshold) {
    return MultiplyClassic(num1, num2);
  } else {
    std::string a = num1.substr(0, num1.size() / 2);
    std::string b = num1.substr(num1.size() / 2, num1.size() - num1.size() / 2);
    std::string c = num2.substr(0, num2.size() / 2);
    std::string d = num2.substr(num2.size() / 2, num2.size() - num2.size() / 2);
    std::string ac = Multiply(a, c);
    std::string bd = Multiply(b, d);
    int x = b.size();
    return Add(
        Add(MultiplyByPowerOf10(ac, std::pow(x, 2)),
            MultiplyByPowerOf10(Subtract(Multiply(Add(a, b), Add(c, d)), Add(ac, bd)), x)), bd);
  }
}

int main() {
  std::ios::sync_with_stdio(false);
  std::cin.tie(nullptr);

  std::string num1, num2;
  std::cin >> num1 >> num2;
  std::string res = Multiply(num1, num2);
  TrimZeroes(res);
  std::cout << res;
}