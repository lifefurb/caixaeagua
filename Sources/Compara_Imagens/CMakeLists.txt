cmake_minimum_required(VERSION 2.8)
project( ComparaImagens )
find_package( OpenCV REQUIRED )
add_executable( ComparaImagens ComparaImagens.cpp )
target_link_libraries( ComparaImagens ${OpenCV_LIBS} )