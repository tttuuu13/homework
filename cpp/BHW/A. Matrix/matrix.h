#pragma once
#include <stdexcept>
#include <iostream>

class MatrixOutOfRange : public std::out_of_range {
 public:
  MatrixOutOfRange() : std::out_of_range("MatrixOutOfRange") {
  }
};

template<typename T, size_t N, size_t M>
class Matrix {
 public:
  T elements[N][M];

  size_t RowsNumber() const {
    return N;
  }
  size_t ColumnsNumber() const {
    return M;
  }

  const T &operator()(size_t i, size_t j) const {
    return elements[i][j];
  };

  T &operator()(size_t i, size_t j) {
    return elements[i][j];
  };

  const T &At(size_t i, size_t j) const {
    if (i >= RowsNumber() || j >= ColumnsNumber()) {
      throw MatrixOutOfRange{};
    }
    return elements[i][j];
  }

  T &At(size_t i, size_t j) {
    if (i >= RowsNumber() || j >= ColumnsNumber()) {
      throw MatrixOutOfRange{};
    }
    return elements[i][j];
  }

  Matrix<T, N, M> operator+(const Matrix<T, N, M> &other) const {
    Matrix<T, N, M> result;
    for (size_t i = 0; i < N; i++) {
      for (size_t j = 0; j < M; j++) {
        result(i, j) = (*this)(i, j) + other(i, j);
      }
    }
    return result;
  }

  Matrix<T, N, M> operator+=(const Matrix<T, N, M> &other) {
    *this = *this + other;
    return *this;
  }

  Matrix<T, N, M> operator-(const Matrix<T, N, M> &other) const {
    Matrix<T, N, M> result;
    for (size_t i = 0; i < N; i++) {
      for (size_t j = 0; j < M; j++) {
        result(i, j) = (*this)(i, j) - other(i, j);
      }
    }
    return result;
  }

  Matrix<T, N, M> operator-=(const Matrix<T, N, M> &other) {
    *this = *this - other;
    return *this;
  }

  template<size_t K>
  Matrix<T, N, K> operator*(const Matrix<T, M, K> &other) const {
    Matrix<T, N, K> result;
    for (size_t i = 0; i < N; i++) {
      for (size_t j = 0; j < K; j++) {
        result(i, j) = 0;
        for (size_t p = 0; p < M; p++) {
          result(i, j) += (*this)(i, p) * other(p, j);
        }
      }
    }
    return result;
  }

  Matrix<T, N, M> operator*=(const Matrix<T, M, M> &other) {
    *this = *this * other;
    return *this;
  }

  Matrix<T, N, M> operator*=(const T &num) {
    *this = *this * num;
    return *this;
  }

  Matrix<T, N, M> operator/=(const T &num) {
    *this = *this / num;
    return *this;
  }

  bool operator==(const Matrix<T, N, M> &other) const {
    for (size_t i = 0; i < N; i++) {
      for (size_t j = 0; j < M; j++) {
        if ((*this)(i, j) != other(i, j)) {
          return false;
        }
      }
    }
    return true;
  }

  bool operator!=(const Matrix<T, N, M> &other) const {
    return !((*this) == other);
  }

  friend Matrix<T, N, M> operator*(const Matrix<T, N, M> &matrix, const T &num) {
    Matrix<T, N, M> result;
    for (size_t i = 0; i < N; i++) {
      for (size_t j = 0; j < M; j++) {
        result(i, j) = matrix(i, j) * num;
      }
    }
    return result;
  }

  friend Matrix<T, N, M> operator*(const T &num, const Matrix<T, N, M> &matrix) {
    return matrix * num;
  }

  friend Matrix<T, N, M> operator/(const Matrix<T, N, M> &matrix, const T &num) {
    Matrix<T, N, M> result;
    for (size_t i = 0; i < N; i++) {
      for (size_t j = 0; j < M; j++) {
        result(i, j) = matrix(i, j) / num;
      }
    }
    return result;
  }

  friend std::istream &operator>>(std::istream &is, Matrix<T, N, M> &matrix) {
    for (size_t row = 0; row < N; row++) {
      for (size_t column = 0; column < M; column++) {
        is >> matrix(row, column);
      }
    }
    return is;
  }

  friend std::ostream &operator<<(std::ostream &os, const Matrix<T, N, M> &matrix) {
    for (size_t row = 0; row < N; row++) {
      for (size_t column = 0; column < M; column++) {
        if (column > 0) {
          os << ' ';
        }
        os << matrix(row, column);
      }
      os << '\n';
    }
    return os;
  }
};

template<typename T, size_t N, size_t M>
Matrix<T, M, N> GetTransposed(const Matrix<T, N, M> &matrix) {
  Matrix<T, M, N> transposed;
  for (size_t i = 0; i < N; i++) {
    for (size_t j = 0; j < M; j++) {
      transposed(j, i) = matrix(i, j);
    }
  }
  return transposed;
}