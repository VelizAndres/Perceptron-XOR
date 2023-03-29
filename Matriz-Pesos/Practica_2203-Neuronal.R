# install.packages(c('tidyverse','neuralnet', 'caret'))
library(neuralnet)
library(tidyverse)
library(caret)
data = iris
muestra = createDataPartition(data$Species,p=0.8, list=F)
train = data[muestra,]
test = data[-muestra,]


red.neuronal = neuralnet(Species ~ Sepal.Length + Sepal.Width + Petal.Length + Petal.Width, data=train, hidden = c(2,3))

# Funcion de activacion
red.neuronal$act.fct

#Diagramar Red Neuronal
plot(red.neuronal)

#Aplicar el conjunto de pruebas a la red para predecir la especie
prediccion = predict(red.neuronal, test, type='class')
prediccion
#Decodificar columna que ocntiene el valor maxiom y por ende la especie
decodificar.col = apply(prediccion, 1, which.max)
decodificar.col
codificado = data_frame(decodificar.col)
codificado = mutate(codificado, especie=recode(codificado$decodificar.col, "1"="Setosa", "2"="versicolor", "3"="virginica"))
test$Species = codificado$especie
codificado


#Visualizar Pesos
red.neuronal$weights 

red.neuronal$weights[1][[1]][[1]]



#Guardar Pesos en txt para luego extraerlos en Jupyter notebook
write.table(red.neuronal$weights[1][[1]][[1]], file = "Peso1.txt", sep = ",", eol = "\n", dec = ".",row.names = TRUE, col.names = TRUE)

write.table(red.neuronal$weights[1][[1]][[2]], file = "Peso2.txt", sep = ",", eol = "\n", dec = ".", row.names = TRUE, col.names = TRUE)

write.table(red.neuronal$weights[1][[1]][[3]], file = "Peso3.txt", sep = ",", eol = "\n", dec = ".", row.names = TRUE, col.names = TRUE)
