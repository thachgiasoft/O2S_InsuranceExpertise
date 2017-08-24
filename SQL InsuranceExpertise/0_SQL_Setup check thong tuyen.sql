--SETUP Check Thong tuyen

//Thêm 2 cột để lưu lại trạng thái
Alter table bhyt add bhytcheckstatus integer;
alter table hosobenhan add bhytcheckstatus integer;

--update bhyt set bhytcheckstatus=0 where bhytcheckstatus=1
--update hosobenhan set bhytcheckstatus=0 where bhytcheckstatus=1


--===========================Trigger Function (Update bhytcheckstatus)

-- Function: trgbhyt_lastaccessdate()
-- DROP FUNCTION trgbhyt_lastaccessdate();

CREATE OR REPLACE FUNCTION trgbhyt_lastaccessdate()
  RETURNS trigger AS
$BODY$
BEGIN
 IF OLD.lastaccessdate <> NEW.lastaccessdate THEN
 UPDATE bhyt SET bhytcheckstatus=0 WHERE bhytid=OLD.bhytid;
 END IF;
 
 RETURN NEW;
END;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION trgbhyt_lastaccessdate()
  OWNER TO postgres;

  
-- Function: trghosobenhan_lastaccessdate()
-- DROP FUNCTION trghosobenhan_lastaccessdate();

CREATE OR REPLACE FUNCTION trghosobenhan_lastaccessdate()
  RETURNS trigger AS
$BODY$
BEGIN
 IF OLD.lastaccessdate <> NEW.lastaccessdate THEN
 UPDATE hosobenhan SET bhytcheckstatus=0 WHERE hosobenhanid=OLD.hosobenhanid;
 END IF;
 
 RETURN NEW;
END;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION trghosobenhan_lastaccessdate()
  OWNER TO postgres;

--===========================Trigger (Update bhytcheckstatus)

-- Trigger: bhytlastaccessdate_change on bhyt
-- DROP TRIGGER bhytlastaccessdate_change ON bhyt;

CREATE TRIGGER bhytlastaccessdate_change
  AFTER UPDATE OF lastaccessdate
  ON bhyt
  FOR EACH ROW
  EXECUTE PROCEDURE trgbhyt_lastaccessdate();
ALTER TABLE bhyt DISABLE TRIGGER bhytlastaccessdate_change;


-- Trigger: hsbalastaccessdate_change on hosobenhan
-- DROP TRIGGER hsbalastaccessdate_change ON hosobenhan;

CREATE TRIGGER hsbalastaccessdate_change
  AFTER UPDATE OF lastaccessdate
  ON hosobenhan
  FOR EACH ROW
  EXECUTE PROCEDURE trghosobenhan_lastaccessdate();
ALTER TABLE hosobenhan DISABLE TRIGGER hsbalastaccessdate_change;









