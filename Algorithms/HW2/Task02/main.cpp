#include <iostream>

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

std::string Multiply(std::string &num1, std::string &num2) {
  const int threshold = 5;
  if (num1.size() + num2.size() < 8) {
    long long a = std::stoll(num1);
    long long b = std::stoll(num2);
    return std::to_string(a * b);
  } else if (num1.size() < threshold) {
    std::string num21 = num2.substr(0, num2.size() / 2);
    std::string num22 = num2.substr(num2.size() / 2, num2.size() - num2.size() / 2);
    return Add(
        MultiplyByPowerOf10(Multiply(num1, num21), num22.size()),
        Multiply(num1, num22)
        );
  } else if (num2.size() < threshold) {
    std::string num11 = num1.substr(0, num1.size() / 2);
    std::string num12 = num1.substr(num1.size() / 2, num1.size() - num1.size() / 2);
    return Add(
        MultiplyByPowerOf10(Multiply(num2, num11), num12.size()),
        Multiply(num2, num12)
    );
  } else {
    std::string num11 = num1.substr(0, num1.size() / 2);
    std::string num12 = num1.substr(num1.size() / 2, num1.size() - num1.size() / 2);
    std::string num21 = num2.substr(0, num2.size() / 2);
    std::string num22 = num2.substr(num2.size() / 2, num2.size() - num2.size() / 2);
    return Add(
        Add(
            MultiplyByPowerOf10(Multiply(num11, num21), num12.size() + num22.size()),
            MultiplyByPowerOf10(Multiply(num11, num22), num12.size())
        ),
        Add(
            MultiplyByPowerOf10(Multiply(num12, num21), num22.size()),
            Multiply(num12, num22)
        )
    );
  }
}

int main() {
  std::ios::sync_with_stdio(false);
  std::cin.tie(nullptr);

  std::string num1, num2;
  std::cin >> num1 >> num2;
  std::cout << Multiply(num1, num2);
}