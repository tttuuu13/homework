#include <iostream>
#include "vector"
using matrix = std::vector<std::vector<long long>>;

matrix MultiplyClassic(matrix &a, matrix &b) {
  matrix res;
  for (int i = 0; i < a.size(); i++) {
    res.emplace_back();
    for (int j = 0; j < a.size(); j++) {
      long long r = 0;
      for (int k = 0; k < a.size(); k++) {
        r += static_cast<long long>(a[i][k]) * b[k][j];
      }
      res.back().emplace_back(r);
    }
  }
  return res;
}

std::vector<matrix> SplitIn4(matrix &a) {
  size_t n = a.size();
  size_t half = n / 2;
  std::vector<matrix> res(4);
  for (int i = 0; i < n / 2; i++) {
    res[0].emplace_back();
    res[1].emplace_back();
    res[2].emplace_back();
    res[3].emplace_back();
    for (int j = 0; j < n / 2; j++) {
      res[0].back().emplace_back(a[i][j]);
      res[1].back().emplace_back(a[i][j + half]);
      res[2].back().emplace_back(a[i + half][j]);
      res[3].back().emplace_back(a[i + half][j + half]);
    }
  }
  return res;
}

matrix Add(matrix a, matrix b) {
  matrix res;
  for (int i = 0; i < a.size(); i++) {
    res.emplace_back();
    for (int j = 0; j < a.size(); j++) {
      res.back().emplace_back(a[i][j] + b[i][j]);
    }
  }
  return res;
}

matrix Subtract(matrix a, matrix b) {
  matrix res;
  for (int i = 0; i < a.size(); i++) {
    res.emplace_back();
    for (int j = 0; j < a.size(); j++) {
      res.back().emplace_back(a[i][j] - b[i][j]);
    }
  }
  return res;
}

matrix Combine(std::vector<matrix> matrices) {
  size_t n = matrices.front().size();
  matrix res(n * 2);
  for (int i = 0; i < n; i++) {
    res[i] = std::vector<long long>(n * 2);
    res[i + n] = std::vector<long long>(n * 2);
    for (int j = 0; j < n; j++) {
      res[i][j] = matrices[0][i][j];
      res[i][j + n] = matrices[1][i][j];
      res[i + n][j] = matrices[2][i][j];
      res[i + n][j + n] = matrices[3][i][j];
    }
  }
  return res;
}

matrix MultiplyStrassen(matrix a, matrix b) {
  size_t n = a.size();
  if (n <= 128) {
    return MultiplyClassic(a, b);
  }
  std::vector<matrix> aSplit = SplitIn4(a);
  std::vector<matrix> bSplit = SplitIn4(b);
  matrix a11 = aSplit[0];
  matrix a12 = aSplit[1];
  matrix a21 = aSplit[2];
  matrix a22 = aSplit[3];
  matrix b11 = bSplit[0];
  matrix b12 = bSplit[1];
  matrix b21 = bSplit[2];
  matrix b22 = bSplit[3];
  matrix m1 = MultiplyStrassen(Add(a11, a22), Add(b11, b22));
  matrix m2 = MultiplyStrassen(Add(a21, a22), b11);
  matrix m3 = MultiplyStrassen(a11, Subtract(b12, b22));
  matrix m4 = MultiplyStrassen(a22, Subtract(b21, b11));
  matrix m5 = MultiplyStrassen(Add(a11, a12), b22);
  matrix m6 = MultiplyStrassen(Subtract(a21, a11), Add(b11, b12));
  matrix m7 = MultiplyStrassen(Subtract(a12, a22), Add(b21, b22));
  matrix c11 = Add(Subtract(Add(m1, m4), m5), m7);
  matrix c12 = Add(m3, m5);
  matrix c21 = Add(m2, m4);
  matrix c22 = Add(Add(Subtract(m1, m2), m3), m6);
  return Combine(std::vector<matrix>{c11, c12, c21, c22});
}

int main() {
  std::ios::sync_with_stdio(false);
  std::cin.tie(nullptr);

  int n;
  std::cin >> n;
  matrix a;
  matrix b;
  for (int i = 0; i < n; i++) {
    a.emplace_back();
    for (int j = 0; j < n; j++) {
      int input;
      std::cin >> input;
      a.back().emplace_back(input);
    }
  }
  for (int i = 0; i < n; i++) {
    b.emplace_back();
    for (int j = 0; j < n; j++) {
      int input;
      std::cin >> input;
      b.back().emplace_back(input);
    }
  }
  matrix res = MultiplyStrassen(a, b);
  for (auto &row : res) {
    for (auto &cell : row) {
      std::cout << cell << " ";
    }
    std::cout << "\n";
  }
}
