# TriangleRecognizer

Input: 三角形的三邊長 (皆輸入 整數)

Output: "什麼類型"的三角形:
#等腰三角形 (isosceles triangle)

#正三角形   (regular triangle) (a= b = c, a > 0)(銳角三角形 的一種)(等腰三角形的 一種)
#直角三角形 (right triangle) (a² + b² = c²)(3,4,5)(9,40,41)
#鈍角三角形 (obtuse triangle)(a² + b² < c²)(9,11,17)
#銳角三角形 (acute triangle) (a² + b² > c²)(5,6,7)
#不是三角形 (not triangle)   (a + b <= c)(4,5,10)

若同時符合兩個以上條件
則輸出為 例如:
// (1)正三角形,銳角三角形,等腰三角形
// (2)等腰三角形,直角三角形 (等腰直角三角形)(isosceles right triangle)


-------------------------------------------------------------------------------------------------------

假設三角形的三個邊長分別是 a,b,c,  c為最長的邊長

(1)如果 a²+b²<c² 則為 "鈍角三角形"
鈍角位於c所對應的角

(2)如果 a²+b²=c² 則為 "直角三角形"
直角位於c所對應的角
ex:
3:4:5
5:12:13
8:15:17
7:24:25
9:40:41


(3)如果 a²+b²>c² 則為 "銳角三角形"
a, b, c 三邊所對應的角均為 銳角


若 c 為最大邊長
別忘了還得滿足 a + b > c
才是謂三角形

若 a + b <= c
那就不構成三角形了


