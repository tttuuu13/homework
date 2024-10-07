cmake_minimum_required(VERSION 3.27)
project(Task01)

set(CMAKE_CXX_STANDARD 17)

add_executable(Task01
        vector.h
        src/vector.cpp
        IShape.h
        point.h
        src/point.cpp
        segment.h
        src/segment.cpp
        line.h
        src/line.cpp
        src/ray.cpp
        ray.h
        src/polygon.cpp
        polygon.h
        src/circle.cpp
        circle.h
        geometry_main.cpp
        src/functions.cpp
        functions.h)
