#include <iostream>
#include <unordered_map>
#include <set>

struct PairComparator {
  bool operator()(const std::pair<int, int> &p1, const std::pair<int, int> &p2) const {
    if (p1.first > p2.first) {
      return true;
    }
    if (p1.first < p2.first) {
      return false;
    }
    return p1.second < p2.second;
  }
};
int main() {
  std::unordered_map<std::string, int> last_vote;
  std::unordered_map<int, int> track_score;
  std::set<std::pair<int, int>, PairComparator> scores;

  std::string command;
  std::string ip;
  int track_id = 0;
  int score = 0;
  int time = 0;
  while (std::cin >> command) {
    if (command == "VOTE") {
      std::cin >> ip >> track_id >> score >> time;
      if (last_vote.find(ip) == last_vote.end() || time - last_vote[ip] >= 600) {
        last_vote[ip] = time;
        if (scores.find(std::make_pair(track_score[track_id], track_id)) != scores.end()) {
          scores.erase(std::make_pair(track_score[track_id], track_id));
        }
        track_score[track_id] += score;
        scores.emplace(track_score[track_id], track_id);
      }
      std::cout << track_score[track_id] << '\n';
    } else if (command == "GET") {
      auto best_track = *scores.begin();
      std::cout << best_track.second << ' ' << best_track.first << '\n';
      scores.erase(std::make_pair(best_track.first, best_track.second));
      track_score[best_track.second] = -1;
    } else {
      std::cout << "OK";
      return 0;
    }
  }
}
