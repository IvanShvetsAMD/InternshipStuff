
-- example of UPDATE with JOIN nedeterminism


CREATE TABLE #A ( ID INT, Payload INT );
CREATE TABLE #B
    (
      PayloadOld INT ,
      PayloadNew INT
    );

INSERT  INTO #A
VALUES  ( 1, 1 );

INSERT  INTO #B
VALUES  ( 1, 2 ),
        ( 1, 3 );

UPDATE  A
SET     A.Payload = B.PayloadNew
FROM    #A A
        INNER JOIN #B B ON A.Payload = B.PayloadOld;

SELECT  *
FROM    #A;

UPDATE  #A
SET     Payload = 1;

CREATE CLUSTERED INDEX CIX_B ON #B ( PayloadNew DESC);

UPDATE  A
SET     A.Payload = B.PayloadNew
FROM    #A A
        INNER JOIN #B B ON A.Payload = B.PayloadOld;

SELECT  *
FROM    #A;

DROP TABLE #A;
DROP TABLE #B;