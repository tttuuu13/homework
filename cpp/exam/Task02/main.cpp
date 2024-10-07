#include <iostream>
#include <memory>
#include <string>
#include <utility>
#include <vector>

class Person {
  std::string name_; // naming
 public:
  Person() = default; // add default constructor
  explicit Person(std::string name) : name_(std::move(name)) {}; // explicit and pass by value and move
  Person(const Person &other) noexcept { // rule of 5
    name_ = other.name_;
  }
  Person(Person &&other) noexcept { // rule of 5
    name_ = other.name_;
    other.name_ = std::string{};
  }
  virtual ~Person() = default;
  virtual void Display() const { // methods naming
    std::cout << "Person: " << name_ << '\n'; // faster
  }
};

class Student : public Person {
  int grade_; // naming
 public:
  Student() : grade_(0) {}; // add default constructor
  Student(std::string name, int grade) : Person(std::move(name)), grade_(grade) {}; // pass by value and move
  void Display() const override {
    std::cout << "Student: " << grade_ << '\n'; // faster
  }
};


int main() {
  std::vector<std::unique_ptr<Person>> people; // use unique pointers
  people.push_back(std::make_unique<Person>("Alice"));
  people.push_back(std::unique_ptr<Person>(new Student("Bob", 90)));

  for (const auto &person : people) {
    person->Display();
  }

  // no need to delete objects manually

  std::vector nums = {1, 2, 3}; // remove int
  nums.erase(std::remove(nums.begin(), nums.end(), 2), nums.end()); // use erase-remove idiom
  for (const auto &elem : nums) {
    std::cout << elem << ' ';
  }
}
